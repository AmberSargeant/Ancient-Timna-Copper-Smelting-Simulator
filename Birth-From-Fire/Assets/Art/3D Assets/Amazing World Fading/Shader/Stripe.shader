Shader "Amazing World Fading/Stripe" {
	Properties {
		[Header(Standard)]
		_MainTex       ("Base", 2D) = "white" {}
		_BumpMap       ("Normal", 2D) = "bump" {}
		_Glossiness    ("Smoothness", Range(0, 1)) = 0.5
		_Metallic      ("Metallic", Range(0, 1)) = 0
		[Header(Desaturation)]
		_Pos           ("Position", Vector) = (0, 0, 0, 0)
		_VisDist       ("Visibility Distance", Range(0.01, 16)) = 8
		_FadeWidth     ("Fade Width", Range(0, 8)) = 2
		_StripeTex     ("Stripe", 2D) = "black" {}
		_StripeColor   ("Stripe Color", Color) = (1, 0.8, 0, 1)
		_StripeWidth   ("Stripe Width", Range(0.01, 0.8)) = 0.1
		_StripeDensity ("Stripe Density", Range(0.1, 20)) = 5
	}
	SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True" }
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
		#pragma surface surf Standard keepalpha vertex:vert
		#pragma multi_compile AWD_SPHERICAL AWD_CUBIC AWD_ROUND_XZ
		#pragma multi_compile _ AWD_INVERSE
		#include "Core.cginc"
		sampler2D _StripeTex;
		float4 _StripeColor;
		float _StripeWidth, _StripeDensity, _StripeBloom;
		void vert (inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.stripeUvw = v.vertex.xyz * _StripeDensity;
		}
		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			float fade = Fade(IN.worldPos);
#ifdef AWD_INVERSE
			fade = 1.0 - fade;
#endif
			float stripex = tex2D(_StripeTex, float2(IN.stripeUvw.x, 1.0 - _StripeWidth)).x;
			float stripey = tex2D(_StripeTex, float2(IN.stripeUvw.y, 1.0 - _StripeWidth)).x;
			float stripez = tex2D(_StripeTex, float2(IN.stripeUvw.z, 1.0 - _StripeWidth)).x;
			float checker = stripex * stripey * stripez;
			
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = lerp(_StripeColor.rgb * _StripeBloom, c.rgb * 2, fade);
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			o.Alpha = lerp(1.0 - checker, c.a, fade);
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	}
	FallBack "Diffuse"
}