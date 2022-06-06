import jpysocket

class Phone():
    def __init__(self, connection, father):
        self.room = None
        self.connection = connection
        self.daddy = father
        self.roomExists=False
        self.code = None
        

    def receive(self):
        while True:
            try:
                message = self.connection.recv(1024)
                if not message:
                    print("Phone disconencted")
                    self.disconnect()
                    break
                    
            except ConnectionAbortedError:
                self.disconnect()
                break

            message = jpysocket.jpydecode(message) # We have to decode our message in such a way where python is able to understand java
            if "code_" in message:
                code = message.split("_")[1]
          
                # Now that we have the code we should check wheather the room the phone is trying to connect to actually exists or not
                print(code)
                self.check_room(code)

            else:
                # So we didn't send a code
                pass

    def send(self, message):
        print("Sending message")
        # We need to encode our python mesasge in such a way that java is able to read it

        msg = jpysocket.jpyencode(message)
        self.connection.sendall(msg)


    def check_room(self, code):
        for i in self.daddy.PCs:
            if str(i.room) == code:
                self.roomExists=True
                break 
        
        if self.roomExists:
            # We assign the room to the object
            self.room = int(code)
            self.send("RoomJoinSucces")
            self.roomExists=False
            return True

        else:
            self.send("InvalidRoom")
            return False



    def disconnect(self):
        print("Phones has disconnected")
        # The phone has disconnected.
        # This means we need to remove this object from the server
        # After that we want to destroy this object completely

        self.daddy.phones.remove(self) # Not sure if this works
