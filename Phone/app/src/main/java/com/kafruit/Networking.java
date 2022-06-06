package com.kafruit;

import android.util.Log;

import java.io.*;
import java.net.Socket;

public class Networking
{
    private static Socket s; // We want this to be still accesible after we go to anther intent

    private DataOutputStream dout;
    private DataInputStream din;

    public boolean ready=false;

    public boolean stop = false;


    public void connect() {


            try
            {
                // So first we check if we are already connected to the server.
                // Like we don't want to start a new connection every game when we can stay connected the whole time
                if (DataHolder.s != null) {
                    s = DataHolder.s;
                }
                else {
                    s = new Socket("10.0.2.2", 6969);
                    DataHolder.s = s;
                }
                dout = new DataOutputStream(s.getOutputStream());
                din = new DataInputStream(s.getInputStream());

                dout.writeUTF("phone");
                dout.flush();;
                ready=true;
            }
            catch (IOException e) { Log.d("lol", e.toString()); }


    }

    public void send(final String message)
    {
        try
        {
            dout = new DataOutputStream(s.getOutputStream());
            dout.writeUTF(message);
            dout.flush();
        }
        catch (Exception ex) {Log.d("lol", ex.toString());}
    }

    public String receive() {
        try
        {
            if (stop) {
                return ""; // Makes us stop listening 
            }

            String msg = din.readUTF();
            return msg;
        }
        catch (Exception ex) {
            Log.d("lol", ex.toString());
            return "";
        }

    }

}
