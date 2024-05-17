using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public class Anim
    {
        public const string ANIM_RUN = "Run";
        public const string ANIM_IDLE = "Idle";
        public const string ANIM_DANCE = "Dance";
        public const string ANIM_DEAD = "Dead";
        public const string ANIM_ATTACK = "Attack";
    }
    public class Tag
    {
        public const string TAG_ENEMY = "Enemy";
        public const string TAG_PLAYER = "Player";
        public const string TAG_CHARACTER = "Character";
    }
}
