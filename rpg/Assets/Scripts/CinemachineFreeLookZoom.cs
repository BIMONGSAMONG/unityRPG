using UnityEngine;

namespace Cinemachine
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class CinemachineFreeLookZoom : MonoBehaviour
    {
        private bool _freeLookActive;

        private CinemachineFreeLook freelook;
        private CinemachineFreeLook.Orbit[] originalOrbits;
        [Tooltip("The minimum scale for the orbits")]
        [Range(0.01f, 1f)]
        public float minScale = 0.025f;

        [Tooltip("The maximum scale for the orbits")]
        [Range(1F, 5f)]
        public float maxScale = 2;

        [Tooltip("The zoom axis.  Value is 0..1.  How much to scale the orbits")]
        [AxisStateProperty]
        public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f, "Mouse ScrollWheel", false);

        void OnValidate()
        {
            minScale = Mathf.Max(0.01f, minScale);
            maxScale = Mathf.Max(minScale, maxScale);
        }
                
        // Use this for initialization        
        private void Start()
        {
            CinemachineCore.GetInputAxis = GetInputAxisCustom;
        }

        void Awake()
        {
            freelook = GetComponentInChildren<CinemachineFreeLook>();
            if (freelook != null)
            {
                originalOrbits = new CinemachineFreeLook.Orbit[freelook.m_Orbits.Length];
                for (int i = 0; i < originalOrbits.Length; i++)
                {
                    originalOrbits[i].m_Height = freelook.m_Orbits[i].m_Height;
                    originalOrbits[i].m_Radius = freelook.m_Orbits[i].m_Radius;
                }
#if UNITY_EDITOR
                SaveDuringPlay.SaveDuringPlay.OnHotSave -= RestoreOriginalOrbits;
                SaveDuringPlay.SaveDuringPlay.OnHotSave += RestoreOriginalOrbits;
#endif
            }
        }

#if UNITY_EDITOR
        private void OnDestroy()
        {
            SaveDuringPlay.SaveDuringPlay.OnHotSave -= RestoreOriginalOrbits;
        }

        private void RestoreOriginalOrbits()
        {
            if (originalOrbits != null)
            {
                for (int i = 0; i < originalOrbits.Length; i++)
                {
                    freelook.m_Orbits[i].m_Height = originalOrbits[i].m_Height;
                    freelook.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius;
                }
            }
        }
#endif

        void Update()
        {
            _freeLookActive = Input.GetMouseButton(0);
                        
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                MouseWheelZoomCamera();
            }
        }

        private float GetInputAxisCustom(string axisName)
        {
            if (axisName == "Mouse X")
            {
                if (Input.GetMouseButton(1))
                {
                    return UnityEngine.Input.GetAxis("Mouse X");
                }
                else
                {
                    return 0;
                }
            }
            else if (axisName == "Mouse Y")
            {
                if (Input.GetMouseButton(1))
                {
                    return UnityEngine.Input.GetAxis("Mouse Y");
                }
                else
                {
                    return 0;
                }
            }
            else if (axisName == "Mouse Wheel")
            {
                return Input.GetAxis("Mouse Wheel");
            }
            return UnityEngine.Input.GetAxis(axisName);
        }      

        public void MouseWheelZoomCamera()
        {
            if (originalOrbits != null)
            {
                zAxis.Update(Time.deltaTime);
                float scale = Mathf.Lerp(minScale, maxScale, zAxis.Value);
                for (int i = 0; i < originalOrbits.Length; i++)
                {
                    freelook.m_Orbits[i].m_Height = originalOrbits[i].m_Height * scale;
                    freelook.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * scale;
                }                
            }
        }
    }
}