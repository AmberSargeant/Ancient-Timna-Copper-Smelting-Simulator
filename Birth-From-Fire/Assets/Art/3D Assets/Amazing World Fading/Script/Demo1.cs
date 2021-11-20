using UnityEngine;

namespace AmazingWorldFading
{
	public class Demo1 : MonoBehaviour
	{
		public Shader[] m_Sdrs = new Shader[5];
		public GameObject m_MainCharacter;
		public bool m_ShowUI = true;
		[Range(0.1f, 64f)] public float m_VisDist = 6f;
		[Range(0f, 5f)] public float m_FadeWidth = 2f;
		public bool m_Inverse = false;
		[Header("Halo")]
		public bool m_HaloEdgeNoise = false;
		[Header("Bright")]
		[Range(0f, 1f)] public float m_BrightIntensity = 0.3f;
		[Header("Desaturation")]
		[Range(0f, 1f)] public float m_Darkness = 0.8f;
		[Header("Stripe")]
		[Range(0f, 0.8f)] public float m_StripeWidth = 0.1f;
		[Range(0.1f, 20f)] public float m_StripeDensity = 5f;
		FadingControl[] m_Objs;
		int m_FadeShape = 0;
		int m_FadeFunc = 0;

		void Start()
		{
			m_Objs = GameObject.FindObjectsOfType<FadingControl>();
			for (int i = 0; i < m_Objs.Length; i++)
			{
				m_Objs[i].Initialize();
				m_Objs[i].ApplyShader(m_Sdrs[m_FadeFunc]);
			}
		}
		void Update()
		{
			for (int i = 0; i < m_Objs.Length; i++)
			{
				m_Objs[i].ApplyShader(m_Sdrs[m_FadeFunc]);
				if (m_FadeShape == 0)
				{
					m_Objs[i].ApplyKeyword("AWD_SPHERICAL", true);
					m_Objs[i].ApplyKeyword("AWD_CUBIC", false);
					m_Objs[i].ApplyKeyword("AWD_ROUND_XZ", false);
				}
				else if (m_FadeShape == 1)
				{
					m_Objs[i].ApplyKeyword("AWD_ROUND_XZ", true);
					m_Objs[i].ApplyKeyword("AWD_CUBIC", false);
					m_Objs[i].ApplyKeyword("AWD_SPHERICAL", false);
				}
				else if (m_FadeShape == 2)
				{
					m_Objs[i].ApplyKeyword("AWD_CUBIC", true);
					m_Objs[i].ApplyKeyword("AWD_SPHERICAL", false);
					m_Objs[i].ApplyKeyword("AWD_ROUND_XZ", false);
				}

				if (m_FadeFunc == 0)
				{
					m_Objs[i].ApplyKeyword("AWD_INVERSE", m_Inverse);
					m_Objs[i].ApplyKeyword("AWD_NOISEHALO", m_HaloEdgeNoise);
				}
				else if (m_FadeFunc == 2 || m_FadeFunc == 4 || m_FadeFunc == 1)
				{
					m_Objs[i].ApplyKeyword("AWD_INVERSE", m_Inverse);
				}

				m_Objs[i].UpdateSelfParameters();
				m_Objs[i].SetMaterialsVector("_Pos", m_MainCharacter.transform.position);
				m_Objs[i].SetMaterialsFloat("_VisDist", m_VisDist);
				if (m_FadeFunc == 3)
					m_Objs[i].SetMaterialsFloat("_FadeWidth", m_FadeWidth / 4f);
				else
					m_Objs[i].SetMaterialsFloat("_FadeWidth", m_FadeWidth);
				m_Objs[i].SetMaterialsFloat("_FadeIntensity", m_BrightIntensity);
				m_Objs[i].SetMaterialsFloat("_Darkness", m_Darkness);
				m_Objs[i].SetMaterialsFloat("_StripeWidth", m_StripeWidth);
				m_Objs[i].SetMaterialsFloat("_StripeDensity", m_StripeDensity);
			}
		}
		void OnGUI()
		{
			if (!m_ShowUI)
				return;

			GUI.Box(new Rect(10, 10, 230, 25), "Amazing World Fading Demo");
			string[] names = { "Spherical", "Round-XZ", "Cubic" };
			m_FadeShape = GUI.SelectionGrid (new Rect(10, 40, 100, 80), m_FadeShape, names, 1);
			string[] names2 = { "Halo", "Bright", "Desaturation", "2 Textures", "Stripe" };
			m_FadeFunc = GUI.SelectionGrid(new Rect(10, 140, 100, 150), m_FadeFunc, names2, 1);
		}
	}
}