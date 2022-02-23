// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8199,x:33701,y:32515,varname:node_8199,prsc:2|diff-3159-OUT,spec-371-OUT,gloss-9056-OUT,normal-1775-RGB,emission-3326-OUT,clip-9364-OUT;n:type:ShaderForge.SFN_Tex2d,id:4312,x:32438,y:32188,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_4312,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2578,x:32050,y:32528,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_2578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3515-OUT;n:type:ShaderForge.SFN_Slider,id:5988,x:31689,y:33005,ptovrint:False,ptlb:Fade Out,ptin:_FadeOut,varname:node_5988,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3026321,max:1;n:type:ShaderForge.SFN_Color,id:3783,x:32202,y:32404,ptovrint:False,ptlb:Fade Out Color,ptin:_FadeOutColor,varname:node_3783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6102941,c2:0.4692951,c3:0.008974922,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1775,x:32626,y:32125,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_1775,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:8628,x:32717,y:32394,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:node_8628,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:371,x:33044,y:32256,varname:node_371,prsc:2|A-4312-A,B-8628-OUT;n:type:ShaderForge.SFN_Blend,id:9364,x:32342,y:32646,varname:node_9364,prsc:2,blmd:10,clmp:True|SRC-2578-R,DST-3548-OUT;n:type:ShaderForge.SFN_Multiply,id:3326,x:33192,y:32601,varname:node_3326,prsc:2|A-3783-RGB,B-4777-OUT,C-7209-OUT;n:type:ShaderForge.SFN_Slider,id:7209,x:33045,y:33148,ptovrint:False,ptlb:Fade Out Emission,ptin:_FadeOutEmission,varname:node_7209,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.516943,max:50;n:type:ShaderForge.SFN_OneMinus,id:3548,x:32043,y:32798,varname:node_3548,prsc:2|IN-5988-OUT;n:type:ShaderForge.SFN_OneMinus,id:8124,x:32518,y:32706,varname:node_8124,prsc:2|IN-9364-OUT;n:type:ShaderForge.SFN_Multiply,id:3159,x:32554,y:32354,varname:node_3159,prsc:2|A-4312-RGB,B-8688-RGB;n:type:ShaderForge.SFN_Color,id:8688,x:32283,y:32264,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_8688,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:2018,x:32717,y:32491,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2018,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:9056,x:33205,y:32161,varname:node_9056,prsc:2|A-4312-A,B-2018-OUT;n:type:ShaderForge.SFN_Panner,id:4605,x:31313,y:32425,varname:node_4605,prsc:2,spu:0,spv:1|UVIN-7977-UVOUT;n:type:ShaderForge.SFN_Slider,id:3649,x:31251,y:32609,ptovrint:False,ptlb:Fade Out Speed,ptin:_FadeOutSpeed,varname:node_3649,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:1,max:1;n:type:ShaderForge.SFN_Subtract,id:8906,x:32095,y:33237,varname:node_8906,prsc:2|A-5302-OUT,B-2944-OUT;n:type:ShaderForge.SFN_Vector1,id:2944,x:31902,y:33388,varname:node_2944,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:4788,x:32277,y:33223,varname:node_4788,prsc:2|IN-8906-OUT;n:type:ShaderForge.SFN_Frac,id:5302,x:31783,y:33220,varname:node_5302,prsc:2|IN-9724-OUT;n:type:ShaderForge.SFN_Panner,id:9809,x:31325,y:33220,varname:node_9809,prsc:2,spu:1,spv:0|UVIN-7977-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:9724,x:31579,y:33220,varname:node_9724,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-9809-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3895,x:32451,y:33202,cmnt:Triangle Wave,varname:node_3895,prsc:2|A-4788-OUT,B-7262-OUT;n:type:ShaderForge.SFN_Vector1,id:7262,x:32188,y:33406,varname:node_7262,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:1521,x:32653,y:33140,cmnt:Panning gradient,varname:node_1521,prsc:2|VAL-3895-OUT,EXP-4892-OUT;n:type:ShaderForge.SFN_Blend,id:4777,x:32804,y:33102,varname:node_4777,prsc:2,blmd:10,clmp:True|SRC-8124-OUT,DST-1521-OUT;n:type:ShaderForge.SFN_Vector1,id:4892,x:32557,y:33302,varname:node_4892,prsc:2,v1:5;n:type:ShaderForge.SFN_Lerp,id:8213,x:31632,y:32402,varname:node_8213,prsc:2|A-7977-UVOUT,B-4605-UVOUT,T-3649-OUT;n:type:ShaderForge.SFN_Multiply,id:228,x:31611,y:32599,varname:node_228,prsc:2|A-4605-UVOUT,B-7255-OUT;n:type:ShaderForge.SFN_Slider,id:7255,x:31251,y:32807,ptovrint:False,ptlb:Alpha Tile,ptin:_AlphaTile,varname:node_7255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:-0.6666667,max:10;n:type:ShaderForge.SFN_Add,id:3515,x:31821,y:32464,varname:node_3515,prsc:2|A-8213-OUT,B-228-OUT;n:type:ShaderForge.SFN_TexCoord,id:7977,x:30938,y:32328,varname:node_7977,prsc:2,uv:0;proporder:8688-3783-7209-5988-8628-2018-3649-7255-4312-1775-2578;pass:END;sub:END;*/

Shader "Wao3DStudio/FX/Fade Out In" {
    Properties {
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _FadeOutColor ("Fade Out Color", Color) = (0.6102941,0.4692951,0.008974922,1)
        _FadeOutEmission ("Fade Out Emission", Range(0, 50)) = 2.516943
        _FadeOut ("Fade Out", Range(0, 1)) = 0.3026321
        _Specularity ("Specularity", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _FadeOutSpeed ("Fade Out Speed", Range(-1, 1)) = 1
        _AlphaTile ("Alpha Tile", Range(-2, 10)) = -0.6666667
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _Alpha ("Alpha", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _FadeOut;
            uniform float4 _FadeOutColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Specularity;
            uniform float _FadeOutEmission;
            uniform float4 _DiffuseColor;
            uniform float _Gloss;
            uniform float _FadeOutSpeed;
            uniform float _AlphaTile;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 node_4922 = _Time + _TimeEditor;
                float2 node_4605 = (i.uv0+node_4922.g*float2(0,1));
                float2 node_3515 = (lerp(i.uv0,node_4605,_FadeOutSpeed)+(node_4605*_AlphaTile));
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(node_3515, _Alpha));
                float node_9364 = saturate(( (1.0 - _FadeOut) > 0.5 ? (1.0-(1.0-2.0*((1.0 - _FadeOut)-0.5))*(1.0-_Alpha_var.r)) : (2.0*(1.0 - _FadeOut)*_Alpha_var.r) ));
                clip(node_9364 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float gloss = (_Diffuse_var.a*_Gloss);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_371 = (_Diffuse_var.a*_Specularity);
                float3 specularColor = float3(node_371,node_371,node_371);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (_FadeOutColor.rgb*saturate(( pow((abs((frac((i.uv0+node_4922.g*float2(1,0)).g)-0.5))*2.0),5.0) > 0.5 ? (1.0-(1.0-2.0*(pow((abs((frac((i.uv0+node_4922.g*float2(1,0)).g)-0.5))*2.0),5.0)-0.5))*(1.0-(1.0 - node_9364))) : (2.0*pow((abs((frac((i.uv0+node_4922.g*float2(1,0)).g)-0.5))*2.0),5.0)*(1.0 - node_9364)) ))*_FadeOutEmission);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _FadeOut;
            uniform float4 _FadeOutColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Specularity;
            uniform float _FadeOutEmission;
            uniform float4 _DiffuseColor;
            uniform float _Gloss;
            uniform float _FadeOutSpeed;
            uniform float _AlphaTile;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 node_7272 = _Time + _TimeEditor;
                float2 node_4605 = (i.uv0+node_7272.g*float2(0,1));
                float2 node_3515 = (lerp(i.uv0,node_4605,_FadeOutSpeed)+(node_4605*_AlphaTile));
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(node_3515, _Alpha));
                float node_9364 = saturate(( (1.0 - _FadeOut) > 0.5 ? (1.0-(1.0-2.0*((1.0 - _FadeOut)-0.5))*(1.0-_Alpha_var.r)) : (2.0*(1.0 - _FadeOut)*_Alpha_var.r) ));
                clip(node_9364 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float gloss = (_Diffuse_var.a*_Gloss);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_371 = (_Diffuse_var.a*_Specularity);
                float3 specularColor = float3(node_371,node_371,node_371);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _FadeOut;
            uniform float _FadeOutSpeed;
            uniform float _AlphaTile;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1587 = _Time + _TimeEditor;
                float2 node_4605 = (i.uv0+node_1587.g*float2(0,1));
                float2 node_3515 = (lerp(i.uv0,node_4605,_FadeOutSpeed)+(node_4605*_AlphaTile));
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(node_3515, _Alpha));
                float node_9364 = saturate(( (1.0 - _FadeOut) > 0.5 ? (1.0-(1.0-2.0*((1.0 - _FadeOut)-0.5))*(1.0-_Alpha_var.r)) : (2.0*(1.0 - _FadeOut)*_Alpha_var.r) ));
                clip(node_9364 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
