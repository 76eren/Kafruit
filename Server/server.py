import socket
import threading as t
import pc
import phone
import jpysocket
print("Lol")
class Networking():
	def __init__(self):
		self.s = socket.socket()
		self.s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
		self.s.bind(("localhost", 6969))
		self.s.listen(5)
		
		self.phones = [] # Phone object
		self.PCs = [] # PC object
		self.code = 0

	def receive_first_time(self):
		while True:
			conn, addr = self.s.accept()
			
			# Right now we still don't know wheter a PC or a phone connected to us
			resp = conn.recv(1024) # this'll tel us who connected

			if resp.decode() == "pc":
				resp = resp.decode()
		
			else:
				resp = jpysocket.jpydecode(resp) # Java needs to be encoded/decoded in a certain way. Jpysocket will make sure this is done correctly


			self.assign_room(conn, resp)
			

	def assign_room(self, conn, origin):
		if origin=="pc": # If a pc connected to us
			cd = (self.generate_code())
			conn.sendall(f"code_{cd}".encode()) # We notify the PC of their room number
			
			# We create a new PC object
			obj = pc.PC(cd, conn, self)
			self.PCs.append(obj)

			listeningThread = t.Thread(target=obj.receive, args=())
			listeningThread.start()


		if "phone" == origin: 
			phone_obj = phone.Phone(conn, self)
			self.phones.append(phone_obj)

			phoneListeningThread = t.Thread(target=phone_obj.receive, args=())
			phoneListeningThread.start()

			

	def generate_code(self):
		self.code += 1
		return self.code





if __name__ == "__main__":
	netObj = Networking()
	startingThread = t.Thread(target=netObj.receive_first_time)
	startingThread.start()