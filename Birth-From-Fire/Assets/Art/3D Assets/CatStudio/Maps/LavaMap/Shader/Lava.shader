// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CatStudio/LavaMap/Lava"
{
	Properties
	{
		_AddColor("AddColor", Color) = (0,0,0,0)
		_Texture1("Texture1", 2D) = "white" {}
		_U_Speed1("U_Speed1", Float) = -0.001
		_V_Speed1("V_Speed1", Float) = 0.003
		_Texture2("Texture2", 2D) = "white" {}
		[Toggle]_Texture2Switch("Texture2Switch", Float) = 1
		_U_Speed2("U_Speed2", Float) = 0.003
		_V_Speed2("V_Speed2", Float) = 0.001
		_NoiseTexture("NoiseTexture", 2D) = "white" {}
		[Toggle]_NoiseSwitch("NoiseSwitch", Float) = 1
		_NoisePower1("NoisePower1", Float) = 0.05
		_NoisePower2("NoisePower2", Float) = 0.05
		_NoiseRotSpeed("NoiseRotSpeed", Float) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 2.0
		#pragma surface surf Standard keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _AddColor;
		uniform float _Texture2Switch;
		uniform sampler2D _Texture1;
		uniform float _NoiseSwitch;
		uniform sampler2D _NoiseTexture;
		uniform float4 _NoiseTexture_ST;
		uniform float _NoiseRotSpeed;
		uniform float _NoisePower1;
		uniform float _U_Speed1;
		uniform float _V_Speed1;
		uniform float4 _Texture1_ST;
		uniform sampler2D _Texture2;
		uniform float _NoisePower2;
		uniform float _U_Speed2;
		uniform float _V_Speed2;
		uniform float4 _Texture2_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NoiseTexture = i.uv_texcoord * _NoiseTexture_ST.xy + _NoiseTexture_ST.zw;
			float cos151 = cos( ( _NoiseRotSpeed * _Time.y ) );
			float sin151 = sin( ( _NoiseRotSpeed * _Time.y ) );
			float2 rotator151 = mul( tex2D( _NoiseTexture, uv_NoiseTexture ).rg - float2( 1,1 ) , float2x2( cos151 , -sin151 , sin151 , cos151 )) + float2( 1,1 );
			float2 appendResult124 = (float2(_U_Speed1 , _V_Speed1));
			float2 uv_Texture1 = i.uv_texcoord * _Texture1_ST.xy + _Texture1_ST.zw;
			float2 panner127 = ( 1.0 * _Time.y * appendResult124 + uv_Texture1);
			float4 tex2DNode138 = tex2D( _Texture1, ( ((( _NoiseSwitch )?( rotator151 ):( float2( 0,0 ) ))*_NoisePower1 + 0.0) + panner127 ) );
			float4 appendResult122 = (float4(_U_Speed2 , _V_Speed2 , 0.0 , 0.0));
			float2 uv_Texture2 = i.uv_texcoord * _Texture2_ST.xy + _Texture2_ST.zw;
			float2 panner128 = ( 1.0 * _Time.y * appendResult122.xy + uv_Texture2);
			float4 temp_output_143_0 = ( _AddColor + (( _Texture2Switch )?( ( tex2DNode138 * tex2D( _Texture2, ( ((( _NoiseSwitch )?( rotator151 ):( float2( 0,0 ) ))*_NoisePower2 + 0.0) + panner128 ) ) ) ):( tex2DNode138 )) );
			o.Albedo = temp_output_143_0.rgb;
			o.Emission = temp_output_143_0.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18800
458;216;1593;1128;876.7819;578.6586;1.390306;True;True
Node;AmplifyShaderEditor.SimpleTimeNode;153;-2141.961,585.723;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;152;-2144.74,434.1796;Float;False;Property;_NoiseRotSpeed;NoiseRotSpeed;12;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;114;-2140.737,165.281;Inherit;True;Property;_NoiseTexture;NoiseTexture;8;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;155;-1893.095,559.307;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;116;-1233.907,718.2737;Float;False;Property;_U_Speed2;U_Speed2;6;0;Create;True;0;0;0;False;0;False;0.003;0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;151;-1806.896,183.9245;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;1,1;False;2;FLOAT;0.5;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;115;-1251.108,63.71423;Float;False;Property;_U_Speed1;U_Speed1;2;0;Create;True;0;0;0;False;0;False;-0.001;-0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-1247.762,165.9081;Float;False;Property;_V_Speed1;V_Speed1;3;0;Create;True;0;0;0;False;0;False;0.003;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;117;-1231.139,835.1378;Float;False;Property;_V_Speed2;V_Speed2;7;0;Create;True;0;0;0;False;0;False;0.001;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;122;-1063.139,726.3381;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;120;-1888.779,-239.1169;Inherit;False;0;131;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;123;-1782.432,736.6124;Inherit;False;0;134;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;119;-1824.903,-78.19672;Float;False;Property;_NoisePower1;NoisePower1;10;0;Create;True;0;0;0;False;0;False;0.05;-0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;121;-1837.018,441.3956;Float;False;Property;_NoisePower2;NoisePower2;11;0;Create;True;0;0;0;False;0;False;0.05;-0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;126;-1566.362,212.1534;Float;False;Property;_NoiseSwitch;NoiseSwitch;9;0;Create;True;0;0;0;False;0;False;1;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;124;-1039.288,67.52039;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;130;-1397.168,-96.01784;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;127;-885.5654,-87.80279;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;128;-804.3717,644.2711;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;129;-1393.775,443.4553;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;132;-618.0878,825.8759;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;131;-747.9525,114.0829;Float;True;Property;_Texture1;Texture1;1;0;Create;True;0;0;0;False;0;False;None;8c23b91ef28e7044ea23308296eff932;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode;134;-794.614,374.3568;Float;True;Property;_Texture2;Texture2;4;0;Create;True;0;0;0;False;0;False;None;8c23b91ef28e7044ea23308296eff932;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleAddOpNode;133;-681.2241,-287.8737;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;136;-410.6177,326.3697;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;138;-436.6092,111.0876;Inherit;True;Property;_TextureSample3;Texture Sample 3;3;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;140;-55.74579,221.9058;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ToggleSwitchNode;144;-79.28125,81.91493;Float;False;Property;_Texture2Switch;Texture2Switch;5;0;Create;True;0;0;0;False;0;False;1;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;135;-197.24,-198.0578;Float;False;Property;_AddColor;AddColor;0;0;Create;True;0;0;0;False;0;False;0,0,0,0;0.3161765,0.03719723,0.03719723,1;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;143;175.9189,-92.46816;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;76;468.3613,34.38048;Float;False;True;-1;0;ASEMaterialInspector;0;0;Standard;CatStudio/LavaMap/Lava;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;155;0;152;0
WireConnection;155;1;153;0
WireConnection;151;0;114;0
WireConnection;151;2;155;0
WireConnection;122;0;116;0
WireConnection;122;1;117;0
WireConnection;126;1;151;0
WireConnection;124;0;115;0
WireConnection;124;1;113;0
WireConnection;130;0;126;0
WireConnection;130;1;119;0
WireConnection;127;0;120;0
WireConnection;127;2;124;0
WireConnection;128;0;123;0
WireConnection;128;2;122;0
WireConnection;129;0;126;0
WireConnection;129;1;121;0
WireConnection;132;0;129;0
WireConnection;132;1;128;0
WireConnection;133;0;130;0
WireConnection;133;1;127;0
WireConnection;136;0;134;0
WireConnection;136;1;132;0
WireConnection;138;0;131;0
WireConnection;138;1;133;0
WireConnection;140;0;138;0
WireConnection;140;1;136;0
WireConnection;144;0;138;0
WireConnection;144;1;140;0
WireConnection;143;0;135;0
WireConnection;143;1;144;0
WireConnection;76;0;143;0
WireConnection;76;2;143;0
ASEEND*/
//CHKSM=9B0726FFB9157FB9E4BF5A78B847B92C8CF0708D