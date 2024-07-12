﻿/// <summary>
/// SURGE FRAMEWORK
/// Author: Bob Berkebile
/// Email: bobb@pixelplacement.com
/// </summary>

using System;
using UnityEngine;

namespace Pixelplacement.TweenSystem
{
    internal class SpriteRendererColor : TweenBase
    {
        //Public Properties:
        public Color EndValue { get; private set; }

        //Private Variables:
        private SpriteRenderer _target;

        private Color _start;

        //Constructor:
        public SpriteRendererColor(SpriteRenderer target, Color endValue, float duration, float delay, bool obeyTimescale, AnimationCurve curve, Tween.LoopType loop, Action startCallback, Action completeCallback)
        {
            //set essential properties:
            SetEssentials(Tween.TweenType.SpriteRendererColor, target.GetInstanceID(), duration, delay, obeyTimescale, curve, loop, startCallback, completeCallback);

            //catalog custom properties:
            _target = target;
            EndValue = endValue;
        }

        //Processes:
        protected override bool SetStartValue()
        {
            if (_target == null) return false;
            _start = _target.color;
            return true;
        }

        protected override void Operation(float percentage)
        {
            Color calculatedValue = TweenUtilities.LinearInterpolate(_start, EndValue, percentage);
            _target.color = calculatedValue;
        }

        //Loops:
        public override void Loop()
        {
            ResetStartTime();
            _target.color = _start;
        }

        public override void PingPong()
        {
            ResetStartTime();
            _target.color = EndValue;
            EndValue = _start;
            _start = _target.color;
        }
    }
}