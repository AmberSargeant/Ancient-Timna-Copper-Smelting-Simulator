// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CatStudio/LavaMap/LavaDown"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Float1("Float 1", Float) = 0.1
		_AddColor("AddColor", Color) = (0,0,0,0)
		_Texture1("Texture1", 2D) = "white" {}
		_U_Speed1("U_Speed1", Float) = -0.001
		_V_Speed1("V_Speed1", Float) = 0.003
		_Texture2("Texture2", 2D) = "white" {}
		_U_Speed2("U_Speed2", Float) = 0.003
		_V_Speed2("V_Speed2", Float) = 0.001
		_NoiseTexture("NoiseTexture", 2D) = "white" {}
		[Toggle]_NoiseSwitch("NoiseSwitch", Float) = 1
		_NoisePower1("NoisePower1", Float) = 0.02
		_NoisePower2("NoisePower2", Float) = 0.02
		_NoiseOffset1("NoiseOffset1", Float) = 0.3
		_NoiseOffset2("NoiseOffset2", Float) = -0.3
		_MaskTexture("MaskTexture", 2D) = "white" {}
		[Toggle]_OffsetSwitch("OffsetSwitch", Float) = 1
		_OffsetTime("OffsetTime", Float) = 0
		_OffsetPower("OffsetPower", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 2.0
		#pragma surface surf Standard keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPosition;
		};

		uniform float _OffsetSwitch;
		uniform float _Float1;
		uniform float _OffsetTime;
		uniform float _OffsetPower;
		uniform float4 _AddColor;
		uniform sampler2D _Texture1;
		uniform float _NoiseSwitch;
		uniform sampler2D _NoiseTexture;
		uniform float4 _NoiseTexture_ST;
		uniform float _NoisePower1;
		uniform float _NoiseOffset1;
		uniform float _U_Speed1;
		uniform float _V_Speed1;
		uniform float4 _Texture1_ST;
		uniform sampler2D _Texture2;
		uniform float _NoisePower2;
		uniform float _NoiseOffset2;
		uniform float _U_Speed2;
		uniform float _V_Speed2;
		uniform float4 _Texture2_ST;
		uniform sampler2D _MaskTexture;
		uniform float4 _MaskTexture_ST;
		uniform float _Cutoff = 0.5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline float Dither8x8Bayer( int x, int y )
		{
			const float dither[ 64 ] = {
				 1, 49, 13, 61,  4, 52, 16, 64,
				33, 17, 45, 29, 36, 20, 48, 32,
				 9, 57,  5, 53, 12, 60,  8, 56,
				41, 25, 37, 21, 44, 28, 40, 24,
				 3, 51, 15, 63,  2, 50, 14, 62,
				35, 19, 47, 31, 34, 18, 46, 30,
				11, 59,  7, 55, 10, 58,  6, 54,
				43, 27, 39, 23, 42, 26, 38, 22};
			int r = y * 8 + x;
			return dither[r] / 64; // same # of instructions as pre-dividing due to compiler magic
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 temp_cast_0 = (_Time.y).xx;
			float simplePerlin2D164 = snoise( temp_cast_0 );
			float3 ase_vertexNormal = v.normal.xyz;
			float3 ase_vertex3Pos = v.vertex.xyz;
			v.vertex.xyz += (( _OffsetSwitch )?( ( ( simplePerlin2D164 * _Float1 * ase_vertexNormal ) * ( sin( ( ( ase_vertex3Pos + _Time.y ) / _OffsetTime ) ) / _OffsetPower ) ) ):( float3( 0,0,0 ) ));
			v.vertex.w = 1;
			float4 ase_screenPos = ComputeScreenPos( UnityObjectToClipPos( v.vertex ) );
			o.screenPosition = ase_screenPos;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NoiseTexture = i.uv_texcoord * _NoiseTexture_ST.xy + _NoiseTexture_ST.zw;
			float2 appendResult35 = (float2(_U_Speed1 , _V_Speed1));
			float2 uv_Texture1 = i.uv_texcoord * _Texture1_ST.xy + _Texture1_ST.zw;
			float2 panner20 = ( 1.0 * _Time.y * appendResult35 + uv_Texture1);
			float4 appendResult38 = (float4(_U_Speed2 , _V_Speed2 , 0.0 , 0.0));
			float2 uv_Texture2 = i.uv_texcoord * _Texture2_ST.xy + _Texture2_ST.zw;
			float2 panner34 = ( 1.0 * _Time.y * appendResult38.xy + uv_Texture2);
			float4 temp_output_184_0 = ( _AddColor + ( tex2D( _Texture1, ( ((( _NoiseSwitch )?( tex2D( _NoiseTexture, uv_NoiseTexture ) ):( float4( 0,0,0,0 ) ))*_NoisePower1 + _NoiseOffset1) + float4( panner20, 0.0 , 0.0 ) ).rg ) * tex2D( _Texture2, ( ((( _NoiseSwitch )?( tex2D( _NoiseTexture, uv_NoiseTexture ) ):( float4( 0,0,0,0 ) ))*_NoisePower2 + _NoiseOffset2) + float4( panner34, 0.0 , 0.0 ) ).rg ) ) );
			o.Albedo = temp_output_184_0.rgb;
			o.Emission = temp_output_184_0.rgb;
			o.Alpha = 1;
			float2 uv_MaskTexture = i.uv_texcoord * _MaskTexture_ST.xy + _MaskTexture_ST.zw;
			float4 ase_screenPos = i.screenPosition;
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float2 clipScreen113 = ase_screenPosNorm.xy * _ScreenParams.xy;
			float dither113 = Dither8x8Bayer( fmod(clipScreen113.x, 8), fmod(clipScreen113.y, 8) );
			clip( ( ( _AddColor.a * tex2D( _MaskTexture, uv_MaskTexture ).a ) / dither113 ) - _Cutoff );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18800
458;210;1593;1134;906.5332;681.7884;1.485;True;True
Node;AmplifyShaderEditor.TimeNode;132;-1410.309,1343.721;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;36;-1173.111,-4.502476;Float;False;Property;_V_Speed1;V_Speed1;5;0;Create;True;0;0;0;False;0;False;0.003;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;131;-1278.886,1085.437;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;17;-1178.022,-91.76521;Float;False;Property;_U_Speed1;U_Speed1;4;0;Create;True;0;0;0;False;0;False;-0.001;-0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-1160.821,562.7942;Float;False;Property;_U_Speed2;U_Speed2;7;0;Create;True;0;0;0;False;0;False;0.003;0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;37;-1158.053,679.6584;Float;False;Property;_V_Speed2;V_Speed2;8;0;Create;True;0;0;0;False;0;False;0.001;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;88;-1754.168,4.894516;Inherit;True;Property;_NoiseTexture;NoiseTexture;9;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;35;-966.2018,-87.95905;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;28;-1741.166,-411.4252;Inherit;False;0;4;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;166;-1063.003,1337.13;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;134;-927.1105,1212.522;Float;False;Property;_OffsetTime;OffsetTime;17;0;Create;True;0;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;173;-1706.96,-262.5129;Float;False;Property;_NoisePower1;NoisePower1;11;0;Create;True;0;0;0;False;0;False;0.02;-0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;38;-990.0535,570.8587;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ToggleSwitchNode;182;-1442.011,13.41887;Float;False;Property;_NoiseSwitch;NoiseSwitch;10;0;Create;True;0;0;0;False;0;False;1;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;66;-1712.758,246.7827;Float;False;Property;_NoisePower2;NoisePower2;12;0;Create;True;0;0;0;False;0;False;0.02;-0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;181;-1733.677,360.3982;Float;False;Property;_NoiseOffset2;NoiseOffset2;14;0;Create;True;0;0;0;False;0;False;-0.3;-0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;33;-1709.346,581.133;Inherit;False;0;30;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;180;-1748.763,-137.4426;Float;False;Property;_NoiseOffset1;NoiseOffset1;13;0;Create;True;0;0;0;False;0;False;0.3;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;135;-699.9108,1113.322;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;5;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PannerNode;34;-731.2857,488.7917;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;20;-754.4274,-262.6348;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;89;-1322.194,266.904;Inherit;False;3;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;87;-1329.948,-239.2824;Inherit;False;3;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;164;-1309.3,1681.06;Inherit;False;Simplex2D;False;False;2;0;FLOAT2;3,3;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;139;-410.1842,822.0422;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;30;-673.3279,181.0773;Float;True;Property;_Texture2;Texture2;6;0;Create;True;0;0;0;False;0;False;None;8c23b91ef28e7044ea23308296eff932;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;137;-699.9108,1209.322;Float;False;Property;_OffsetPower;OffsetPower;18;0;Create;True;0;0;0;False;0;False;0;12;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;4;-674.8666,-41.39658;Float;True;Property;_Texture1;Texture1;3;0;Create;True;0;0;0;False;0;False;None;8c23b91ef28e7044ea23308296eff932;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleAddOpNode;170;-562.354,-412.0143;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT2;0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;68;-545.0019,670.3964;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT2;0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SinOpNode;136;-540.7409,1107.202;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;155;-1291.879,1841.618;Float;False;Property;_Float1;Float 1;1;0;Create;True;0;0;0;False;0;False;0.1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;90;-124.1541,-353.5372;Float;False;Property;_AddColor;AddColor;2;0;Create;True;0;0;0;False;0;False;0,0,0,0;0.3161765,0.03719723,0.03719723,1;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;119;-300.575,445.1033;Inherit;True;Property;_MaskTexture;MaskTexture;15;0;Create;True;0;0;0;False;0;False;-1;None;5aeabb16e918ef24d8d3d6b4bd0a660d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;29;-337.5318,170.8902;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;165;-1040.7,1716.635;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;138;-263.1316,1121.252;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;10;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;5;-363.5233,-44.39183;Inherit;True;Property;_TextureSample0;Texture Sample 0;3;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;118;234.0189,-14.04906;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;-9.389858,17.42141;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;141;84.0885,969.3214;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DitheringNode;113;29.40241,541.4053;Inherit;False;1;False;4;0;FLOAT;0;False;1;SAMPLER2D;;False;2;FLOAT4;0,0,0,0;False;3;SAMPLERSTATE;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;117;236.8746,209.2807;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;112;173.6649,741.3165;Float;False;Property;_OffsetSwitch;OffsetSwitch;16;0;Create;True;0;0;0;False;0;False;1;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;184;244.3421,-237.0311;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;76;468.3613,34.38048;Float;False;True;-1;0;ASEMaterialInspector;0;0;Standard;CatStudio/LavaMap/LavaDown;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;False;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;35;0;17;0
WireConnection;35;1;36;0
WireConnection;166;0;131;0
WireConnection;166;1;132;2
WireConnection;38;0;32;0
WireConnection;38;1;37;0
WireConnection;182;1;88;0
WireConnection;135;0;166;0
WireConnection;135;1;134;0
WireConnection;34;0;33;0
WireConnection;34;2;38;0
WireConnection;20;0;28;0
WireConnection;20;2;35;0
WireConnection;89;0;182;0
WireConnection;89;1;66;0
WireConnection;89;2;181;0
WireConnection;87;0;182;0
WireConnection;87;1;173;0
WireConnection;87;2;180;0
WireConnection;164;0;132;2
WireConnection;170;0;87;0
WireConnection;170;1;20;0
WireConnection;68;0;89;0
WireConnection;68;1;34;0
WireConnection;136;0;135;0
WireConnection;29;0;30;0
WireConnection;29;1;68;0
WireConnection;165;0;164;0
WireConnection;165;1;155;0
WireConnection;165;2;139;0
WireConnection;138;0;136;0
WireConnection;138;1;137;0
WireConnection;5;0;4;0
WireConnection;5;1;170;0
WireConnection;118;0;90;4
WireConnection;118;1;119;4
WireConnection;78;0;5;0
WireConnection;78;1;29;0
WireConnection;141;0;165;0
WireConnection;141;1;138;0
WireConnection;117;0;118;0
WireConnection;117;1;113;0
WireConnection;112;1;141;0
WireConnection;184;0;90;0
WireConnection;184;1;78;0
WireConnection;76;0;184;0
WireConnection;76;2;184;0
WireConnection;76;10;117;0
WireConnection;76;11;112;0
ASEEND*/
//CHKSM=24C95EE103E0235A3B9E29B83779EC7AC890D05C