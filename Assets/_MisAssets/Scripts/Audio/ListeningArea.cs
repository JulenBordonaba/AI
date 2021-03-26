using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{

    public class ListeningArea : AudioElement
    {

        public Vector3 center = Vector3.zero;

        [Min(0.00001f)]
        public float radius = 1;

        public AreaDisplayMode gizmoDisplayMode;

        [Min(0f)]
        public float minSoundPower = 0f;

        private List<string> listenedAudios = new List<string>();

        public void OnDrawGizmos()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = rotationMatrix;

            switch(gizmoDisplayMode)
            {
                case AreaDisplayMode.full:
                    DrawSphere();
                    DrawRadius();
                    break;
                case AreaDisplayMode.radius:
                    DrawRadius();
                    break;
                case AreaDisplayMode.sphere:
                    DrawSphere();
                    break;
                default:
                    break;
            }
        }
        
        private void DrawSphere()
        {
            Gizmos.color = Color.cyan;
            float alpha = this.enabled ? 0.3f : 0f;
            Gizmos.color = new Color(Gizmos.color.r, Gizmos.color.g, Gizmos.color.b, alpha);

            Gizmos.DrawSphere(GizmoPosition, this.radius);
        }

        private void DrawRadius()
        {
            Gizmos.color = RadiusColor;
            float alpha = this.enabled ? 1f : 0.3f;
            Gizmos.color = new Color(Gizmos.color.r, Gizmos.color.g, Gizmos.color.b, alpha);

            Gizmos.DrawWireSphere(GizmoPosition, this.radius);
        }

        public override void OnAudioAreaEnter(AudioArea src)
        {
            
        }

        public override void OnAudioAreaExit(AudioArea src)
        {
            
        }
        

        private Vector3 GizmoPosition
        {
            get
            {
                Vector3 offset;

                offset = this.center;

                return Vector3.zero + offset;
            }
        }

        private Color RadiusColor
        {
            get
            {
                return new Color(0.58f, 1f, 0.67f);
            }
        }


    }
}
