package com.kafruit;

import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.annotation.WorkerThread;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;

import java.util.HashMap;

public class MainActivity extends AppCompatActivity
{
    public Button join;
    public TextView room;
    public TextView label;
    public TextView successLabel;

    public HashMap<String, TextView> map = new HashMap<>();
    public Networking networking;
    private Commands cmds;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        join = (Button) findViewById(R.id.join);
        room = (TextView)findViewById(R.id.input);
        label = (TextView)findViewById(R.id.lable);
        successLabel = (TextView)findViewById(R.id.succesLabel);

        networking = new Networking(); // We create a networking object


        // We set up the Commands thingy
        map.put("room", room);
        map.put("label", label);
        map.put("successLabel", successLabel);

        // We have to set up our commands
        cmds = new Commands();
        cmds.widgets = map;
        cmds.networking = networking;
        cmds.context=this;


        successLabel.setVisibility(View.INVISIBLE); // We make this label invisible


        new Thread(new Runnable()
        {
            @Override
            public void run()
            {
                networking.connect(); // First we connect to the server


                while (true) {
                    final String command = networking.receive();
                    if (command.equals(""))
                    {
                        Log.d("lol", "Stopping listener");
                        return;
                    }

                    runOnUiThread(new Runnable()
                    {
                        @Override
                        public void run()
                        {
                            cmds.execute(command);
                        }
                    });

                }

            }
        }).start();


        join.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Thread t = new Thread(new Runnable()
                {
                    @Override
                    public void run()
                    {
                        networking.send("code_"+room.getText().toString());

                    }
                });
                t.start();
            }
        });

    }


}