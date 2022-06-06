package com.kafruit;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.constraintlayout.widget.ConstraintLayout;
import org.json.JSONArray;
import org.json.JSONObject;

import java.lang.reflect.Array;
import java.util.ArrayList;

public class Game
{
    public ArrayList<String> StringQuiz;
    public ArrayList<JSONObject> quiz = new ArrayList<>();
    public ArrayList<Button> buttons;

    public TextView questionWidget;
    public TextView reveal;
    public TextView time;
    public ConstraintLayout cl;

    int round = 0;
    int choice = -1;
    boolean goNext = false;
    int corrects = 0;
    boolean endgame= false;
    boolean timerStarted=false;
    int maxTime = 11; // x seconds each question

    public Activity activity;

    public void setup() {
        for (String i : StringQuiz) {
            try
            {
                JSONObject jsonObject = new JSONObject(i);
                quiz.add(jsonObject);
            }
            catch (Exception ex) {
                Log.d("lol", ex.toString());
            }
        }

        // We set up a listener to go to the next question
        cl.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                StartRound();
            }
        });
    }



    public void StartRound() {
        if (round == quiz.toArray().length) {
            if (endgame) {
                //  This here is broken
                Intent intent = new Intent(activity, MainActivity.class);
                activity.startActivity(intent);
                return;
            }

            endscreen();
            return;
        }

        round++;
        reset();
        startTimer();
        try
        {
            questionWidget.setText(quiz.get(round-1).get("Q").toString());
            String[] names = {"A1", "A2", "A3", "A4"};
            int pos = 0;
            for (Button i : buttons) {
                i.setText(quiz.get(round-1).get(names[pos]).toString());
                pos++;
            }


        }
        catch (Exception ex) {
            Log.d("lol", ex.toString());
        }


    }


    public void choose(final int choice) {
        // 1 = a
        // 2 = b
        // 3 = c
        // 4 = d
        activity.runOnUiThread(new Runnable()
        {
            @Override
            public void run()
            {
                try
                {

                    timerStarted=false;
                    JSONArray x = (JSONArray) quiz.get(round-1).get("correctAns");
                    ArrayList<Integer> answers = new ArrayList();

                    for (int p = 0; p<x.length();p++) {
                        answers.add((int) x.get(p));
                    }


                    // Now it's time for the grand reveal
                    for (Button i : buttons) {
                        i.setVisibility(View.INVISIBLE);
                    }

                    questionWidget.setVisibility(View.INVISIBLE);
                    time.setVisibility(View.INVISIBLE);
                    reveal.setVisibility(View.VISIBLE);

                    if (answers.contains(choice))
                    {
                        reveal.setText("Your answer is correct");
                        cl.setBackgroundColor(Color.parseColor("#0cff00"));
                        corrects++;

                    }
                    else {
                        reveal.setText("Your answer is incorrect");
                        cl.setBackgroundColor(Color.parseColor("#ff0000"));

                    }

                    if (choice == 69) {
                        reveal.setText("Your time is up");
                        cl.setBackgroundColor(Color.parseColor("#ff0000"));
                    }

                    Log.d("lol", "UHFpuisehfpiashgoisrahgpiyu");


                }
                catch (Exception ex) {
                    Log.d("lol", ex.toString());
                }
            }
        });
    }

    private void reset() {
        cl.setBackgroundColor(Color.parseColor("#C5D5B4")); // Hardcoding UwU
        for (Button i : buttons) {
            i.setVisibility(View.VISIBLE);
        }
        questionWidget.setVisibility(View.VISIBLE);
        reveal.setVisibility(View.INVISIBLE);
        time.setVisibility(View.VISIBLE);

    }

    private void endscreen() {
        endgame=true;
        reveal.setText("This is the end of the game, goodbye, you got "+corrects+" out of the "+quiz.toArray().length+" questions right");
        if (corrects > quiz.toArray().length / 2 ) {
            cl.setBackgroundColor(Color.parseColor("#0cff00"));
        }
        else {
            cl.setBackgroundColor(Color.parseColor("#ff0000"));
        }
    }

    private void startTimer() {
        new Thread(new Runnable()
        {
            @Override
            public void run()
            {
                int timer = maxTime;
                timerStarted=true;
                while (timer>0) {
                    if (!timerStarted) {
                        // If the round has already ended we just return and kill this thread
                        return;
                    }

                    timer--;
                    time.setText(String.valueOf(timer));

                    try
                    {
                        Thread.sleep(1000);
                    }
                    catch (InterruptedException e)
                    {
                        Log.d("lol", e.toString());
                    }
                }

                // We check one last time... Just in case.
                if (!timerStarted) {
                    // If the round has already ended we just return and kill this thread
                    return;
                }

                choose(69);


            }
        }).start();
    }



}
