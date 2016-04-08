/*using System;
using UnityEngine;

namespace Blastro.Movement
{
    public struct InputResults
    {
        public readonly Vector2 LeftStickAxis;
        public readonly Vector2 DpadAxis;
        public readonly Vector2 RightStickAxis;
        public readonly float LeftTrigger;
        public readonly float RightTrigger;
        public readonly bool A;
        public readonly bool B;
        public readonly bool X;
        public readonly bool Y;
        public readonly bool LeftBumper;
        public readonly bool RightBumper;
        public readonly bool Start;
        public readonly bool Select;
        public readonly bool LeftStickClick;
        public readonly bool RightStickClick;

        public InputResults(Vector2 leftStickAxis, Vector2 dPadAxis, Vector2 rightStickAxis, float leftTrigger,
            float rightTrigger, bool a, bool b, bool x, bool y, bool leftBumper, bool rightBumper, bool start,
            bool select, bool leftStickClick, bool rightStickClick)
        {
            LeftStickAxis = leftStickAxis;
            DpadAxis = dPadAxis;
            RightStickAxis = rightStickAxis;
            LeftTrigger = leftTrigger;
            RightTrigger = rightTrigger;
            A = a;
            B = b;
            X = x;
            Y = y;
            LeftBumper = leftBumper;
            RightBumper = rightBumper;
            Start = start;
            Select = select;
            LeftStickClick = leftStickClick;
            RightStickClick = rightStickClick;
        }

        public bool Equals(InputResults other)
        {
            return LeftStickAxis.Equals(other.LeftStickAxis) 
                   && DpadAxis.Equals(other.DpadAxis) 
                   && RightStickAxis.Equals(other.RightStickAxis) 
                   && LeftTrigger.Equals(other.LeftTrigger) 
                   && RightTrigger.Equals(other.RightTrigger) 
                   && A.Equals(other.A) && B.Equals(other.B) 
                   && X.Equals(other.X) && Y.Equals(other.Y) 
                   && LeftBumper.Equals(other.LeftBumper) 
                   && RightBumper.Equals(other.RightBumper) 
                   && Start.Equals(other.Start) 
                   && Select.Equals(other.Select) 
                   && LeftStickClick.Equals(other.LeftStickClick) 
                   && RightStickClick.Equals(other.RightStickClick);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is InputResults && Equals((InputResults) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = LeftStickAxis.GetHashCode();
                hashCode = (hashCode*397) ^ DpadAxis.GetHashCode();
                hashCode = (hashCode*397) ^ RightStickAxis.GetHashCode();
                hashCode = (hashCode*397) ^ LeftTrigger.GetHashCode();
                hashCode = (hashCode*397) ^ RightTrigger.GetHashCode();
                hashCode = (hashCode*397) ^ A.GetHashCode();
                hashCode = (hashCode*397) ^ B.GetHashCode();
                hashCode = (hashCode*397) ^ X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ LeftBumper.GetHashCode();
                hashCode = (hashCode*397) ^ RightBumper.GetHashCode();
                hashCode = (hashCode*397) ^ Start.GetHashCode();
                hashCode = (hashCode*397) ^ Select.GetHashCode();
                hashCode = (hashCode*397) ^ LeftStickClick.GetHashCode();
                hashCode = (hashCode*397) ^ RightStickClick.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator == (InputResults a, InputResults b)
        {
            if (a.A != b.A) return false;
            if (a.B != b.B) return false;
            if (a.X != b.X) return false;
            if (a.Y != b.Y) return false;
            if (a.LeftBumper != b.LeftBumper) return false;
            if (a.RightBumper != b.RightBumper) return false;
            if (a.Start != b.Start) return false;
            if (a.Select != b.Select) return false;
            if (a.LeftStickClick != b.LeftStickClick) return false;
            if (a.RightStickClick != b.RightStickClick) return false;
            if (Math.Abs(a.LeftTrigger - b.LeftTrigger) > float.Epsilon) return false;
            if (Math.Abs(a.RightTrigger - b.RightTrigger) > float.Epsilon) return false;
            if (a.LeftStickAxis != b.LeftStickAxis) return false;
            if (a.DpadAxis != b.DpadAxis) return false;
            if (a.RightStickAxis != b.RightStickAxis) return false;

            return true;
        }

        public static bool operator != (InputResults a, InputResults b)
        {
            return !(a == b);
        }
    }
}*/