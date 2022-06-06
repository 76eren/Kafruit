class PC:
	def __init__(self, room, connection, father):
		self.room = room
		self.connection=connection
		self.daddy = father
		self.listen=False

	def receive(self):
		self.quiz = []
		

		while True:
			response = self.connection.recv(1024).decode()
			# So the data is going to come in like this
			# Start -> quiz -> end
			
			if response=="start":
				self.quiz=["start"]
				self.listen=True

			if self.listen:
				if response != "end" and response != "start":
					self.quiz.append(response)

				elif response=="end":
					# This forwards the quiz
					self.listen=False
					self.quiz.append("stop")
					self.forward()
					


	def send(self, msg):
		self.connection.sendall(msg.encode())



	def forward(self):
		# This function will forward out quiz to all of the devices in the same room
		for i in self.daddy.phones:
			if i.room == self.room:
				for x in self.quiz: # I still feel like the way I did this is kinda dumb
					i.send(x)



