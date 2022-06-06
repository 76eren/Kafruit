package com.kafruit;


import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.View;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

public class Commands
{
    public HashMap<String, TextView> widgets = new HashMap<>();
    public Networking networking;
    Activity context;
    boolean adding = false;
    ArrayList<String> quiz = new ArrayList<>();

    public void execute(String cmd) {
        if (adding && !cmd.equals("stop")) {
            quiz.add(cmd);
        }

        switch (cmd) {
            case "InvalidRoom":
                widgets.get("label").setText("Invalid room");

                break;

            case "RoomJoinSucces":
                widgets.get("label").setVisibility(View.INVISIBLE);
                widgets.get("room").setVisibility(View.INVISIBLE);
                widgets.get("successLabel").setVisibility(View.VISIBLE);
                break;

            case "start":
                adding=true;
                break;

            case "stop":
                adding=false;
                networking.stop=true;

                Intent intent=new Intent((Context) context, GameActivity.class);
                intent.putExtra("quiz", quiz);
                context.startActivity(intent);
                break;
        }
    }
}
