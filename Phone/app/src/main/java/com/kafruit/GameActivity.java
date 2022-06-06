package com.kafruit;

import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import androidx.constraintlayout.widget.ConstraintLayout;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class GameActivity extends AppCompatActivity
{
    ArrayList<String> quiz = new ArrayList<>(); // Change this to be an empty quiz variable later please
    ArrayList<TextView> texts = new ArrayList<>();



    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);
        // We create a Game object for the actual game
        final Game game = new Game();

        // Now we do some setting up

        // We assign some values so our game object has stuff to work with
        // There probably is a better way of doing this but I'm an idiot
        game.questionWidget= (TextView)findViewById(R.id.question);
        game.reveal = (TextView)findViewById(R.id.reveal);
        game.reveal.setVisibility(View.INVISIBLE);
        game.time = (TextView)findViewById(R.id.timer);
        game.cl = (ConstraintLayout)findViewById(R.id.main);
        game.activity=this;

        // We set up our buttons
        Button a = (Button) findViewById(R.id.a);
        Button b = (Button) findViewById(R.id.b);
        Button c =(Button) findViewById(R.id.c);
        Button d = (Button) findViewById(R.id.d);

        // We make a button click listener
        ArrayList<Button> buttons = new ArrayList<>();
        buttons.add(a);
        buttons.add(b);
        buttons.add(c);
        buttons.add(d);
        game.buttons = buttons;

        int num = 1;
        for (final Button i : buttons) {
            final int finalNum = num;
            i.setOnClickListener(new View.OnClickListener()
            {
                @Override
                public void onClick(View v)
                {
                    game.choose(finalNum);
                }
            });
            num++;
        }



        Intent intent = getIntent();
        quiz = intent.getStringArrayListExtra("quiz"); // this arraylist contains all of the questions with data
        for (String i : quiz) {
            Log.d("lol", i.toString());
        }

        game.StringQuiz = quiz;

        // We setup our quiz
        game.setup();
        game.StartRound();

    }



}