#!/bin/sh
javac src/com/some_company/plugin/AdPluginActivity.java -classpath "c:/Program Files (x86)/Unity/Editor/Data/PlaybackEngines/androidplayer/bin/classes.jar;./qwandroidsdk.jar;./admob-sdk-android.jar" -bootclasspath $ANDROID_SDK_ROOT/platforms/android-8/android.jar -d .
jar cvfM plugin.jar com/
