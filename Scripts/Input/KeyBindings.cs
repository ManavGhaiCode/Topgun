using System;
using UnityEngine;

[System.Serializable]
public class KeyBindings {
    [SerializeField] private KeyCode[] KeyBinds;
    [SerializeField] private MouseKeyCode[] MouseKeyBinds;

    public string GetKey(string Func) {
        KeyCode Key = Array.Find(KeyBinds, kc => kc.Func == Func);

        if (Key != null) {
            return Key.Key;
        }

        return "null";
    }

    public int GetMouseKey(string Func) {
        MouseKeyCode MouseKey = Array.Find(MouseKeyBinds, mc => mc.Func == Func);

        if (MouseKey != null) {
            return MouseKey.Key;
        }

        return -1;
    }
}