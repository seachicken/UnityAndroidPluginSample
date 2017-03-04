package com.example.androidplugin;

import android.os.Bundle;
import android.widget.Toast;

import com.unity3d.player.UnityPlayerActivity;

public class SampleActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        // 拡張に成功したら"Android拡張成功！"とToast表示
        Toast.makeText(this, R.string.complete_message, Toast.LENGTH_LONG).show();
    }
}