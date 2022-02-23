// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:6949,x:33340,y:32567,varname:node_6949,prsc:2|diff-8082-OUT,spec-5340-OUT,gloss-796-OUT,normal-330-OUT,emission-798-OUT,amdfl-9920-OUT,difocc-7432-OUT,clip-1059-OUT;n:type:ShaderForge.SFN_Tex2d,id:9793,x:31523,y:32529,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_9793,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9a82ba3637fda544bbec3d41b06d2c69,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3024,x:31688,y:31822,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_3024,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6301daaba8586aa4c968979393c4854f,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:5063,x:31787,y:32484,varname:node_5063,prsc:2|A-856-RGB,B-9793-RGB,C-8796-OUT;n:type:ShaderForge.SFN_Color,id:856,x:31523,y:32353,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_856,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:8521,x:31555,y:32220,ptovrint:False,ptlb:Smoothness,ptin:_Smoothness,varname:node_8521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.75,max:2;n:type:ShaderForge.SFN_Tex2d,id:5747,x:31688,y:32009,ptovrint:False,ptlb:Specular Map,ptin:_SpecularMap,varname:node_5747,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:18e2522455376624a90d9e1950f7cb55,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1412,x:31688,y:31636,ptovrint:False,ptlb:AO Map,ptin:_AOMap,varname:node_1412,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:69d4bb83b032af640bd5667ffcd59dd5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:8796,x:31523,y:32719,ptovrint:False,ptlb:Self Ilumination,ptin:_SelfIlumination,varname:node_8796,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_AmbientLight,id:8197,x:31750,y:32666,varname:node_8197,prsc:2;n:type:ShaderForge.SFN_Set,id:6795,x:31999,y:32501,varname:Diff,prsc:2|IN-5063-OUT;n:type:ShaderForge.SFN_Set,id:7893,x:31997,y:32013,varname:Spec,prsc:2|IN-5747-RGB;n:type:ShaderForge.SFN_Set,id:4455,x:31935,y:32217,varname:Smooth,prsc:2|IN-8521-OUT;n:type:ShaderForge.SFN_Set,id:1833,x:31912,y:31822,varname:nor,prsc:2|IN-3024-RGB;n:type:ShaderForge.SFN_Set,id:3753,x:32159,y:31519,varname:AO,prsc:2|IN-5671-OUT;n:type:ShaderForge.SFN_Set,id:7977,x:31796,y:33534,varname:Emm,prsc:2|IN-167-OUT;n:type:ShaderForge.SFN_Set,id:3696,x:31425,y:33618,varname:OAcity,prsc:2|IN-2484-OUT;n:type:ShaderForge.SFN_Get,id:8082,x:33043,y:32473,varname:node_8082,prsc:2|IN-6795-OUT;n:type:ShaderForge.SFN_Get,id:5340,x:33043,y:32523,varname:node_5340,prsc:2|IN-7893-OUT;n:type:ShaderForge.SFN_Get,id:796,x:33043,y:32574,varname:node_796,prsc:2|IN-4455-OUT;n:type:ShaderForge.SFN_Get,id:330,x:33043,y:32624,varname:node_330,prsc:2|IN-1833-OUT;n:type:ShaderForge.SFN_Get,id:798,x:33043,y:32675,varname:node_798,prsc:2|IN-7977-OUT;n:type:ShaderForge.SFN_Get,id:7432,x:33043,y:32772,varname:node_7432,prsc:2|IN-3753-OUT;n:type:ShaderForge.SFN_Get,id:1059,x:33043,y:32830,varname:node_1059,prsc:2|IN-3696-OUT;n:type:ShaderForge.SFN_LightColor,id:4555,x:31750,y:32791,varname:node_4555,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3845,x:31922,y:32745,varname:node_3845,prsc:2|A-8197-RGB,B-4555-RGB;n:type:ShaderForge.SFN_Set,id:8569,x:32095,y:32781,varname:AL,prsc:2|IN-3845-OUT;n:type:ShaderForge.SFN_Get,id:9920,x:33043,y:32723,varname:node_9920,prsc:2|IN-8569-OUT;n:type:ShaderForge.SFN_Tex2d,id:9725,x:30633,y:33378,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:8969,x:29889,y:34089,ptovrint:False,ptlb:Fade,ptin:_Fade,varname:_Fade_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Color,id:9903,x:31262,y:33347,ptovrint:False,ptlb:Fade Out Color,ptin:_FadeOutColor,varname:_FadeOutColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5220588,c2:0.8615618,c3:1,c4:1;n:type:ShaderForge.SFN_Blend,id:2484,x:31093,y:33608,varname:node_2484,prsc:2,blmd:19,clmp:True|SRC-9725-R,DST-8715-OUT;n:type:ShaderForge.SFN_Multiply,id:167,x:31586,y:33534,varname:node_167,prsc:2|A-398-OUT,B-5895-OUT,C-9903-RGB;n:type:ShaderForge.SFN_OneMinus,id:3105,x:30299,y:33907,varname:node_3105,prsc:2|IN-8969-OUT;n:type:ShaderForge.SFN_OneMinus,id:398,x:31262,y:33566,varname:node_398,prsc:2|IN-2484-OUT;n:type:ShaderForge.SFN_TexCoord,id:2976,x:29394,y:33584,varname:node_2976,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:6848,x:30438,y:34111,ptovrint:False,ptlb:Line Thikness,ptin:_LineThikness,varname:_LineThikness_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Power,id:1237,x:30810,y:33880,varname:node_1237,prsc:2|VAL-3708-OUT,EXP-6848-OUT;n:type:ShaderForge.SFN_Multiply,id:3708,x:30612,y:33920,varname:node_3708,prsc:2|A-273-OUT,B-8969-OUT;n:type:ShaderForge.SFN_Divide,id:273,x:30590,y:33720,varname:node_273,prsc:2|A-9584-OUT,B-3105-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9159,x:29956,y:33546,ptovrint:False,ptlb:Right_Left,ptin:_Right_Left,varname:node_6848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2976-U,B-1358-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:8573,x:29956,y:33705,ptovrint:False,ptlb:Up_Down,ptin:_Up_Down,varname:_VerticalHorizontal_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2976-V,B-1466-OUT;n:type:ShaderForge.SFN_OneMinus,id:1358,x:29713,y:33501,varname:node_1358,prsc:2|IN-2976-U;n:type:ShaderForge.SFN_OneMinus,id:1466,x:29698,y:33767,varname:node_1466,prsc:2|IN-2976-V;n:type:ShaderForge.SFN_SwitchProperty,id:3991,x:30187,y:33617,ptovrint:False,ptlb:UV Swich,ptin:_UVSwich,varname:_Horizontal_Swith_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9159-OUT,B-8573-OUT;n:type:ShaderForge.SFN_RemapRange,id:8715,x:30979,y:33816,varname:node_8715,prsc:2,frmn:0,frmx:1,tomn:-1.2,tomx:1.2|IN-1237-OUT;n:type:ShaderForge.SFN_Desaturate,id:4943,x:30138,y:33328,varname:node_4943,prsc:2|COL-2976-UVOUT;n:type:ShaderForge.SFN_SwitchProperty,id:9584,x:30408,y:33590,ptovrint:False,ptlb:UV Activation,ptin:_UVActivation,varname:node_9584,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9274-OUT,B-3991-OUT;n:type:ShaderForge.SFN_Vector1,id:9274,x:30213,y:33515,varname:node_9274,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:5816,x:31341,y:31484,ptovrint:False,ptlb:AO Power,ptin:_AOPower,varname:node_5816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:100;n:type:ShaderForge.SFN_ValueProperty,id:5895,x:31308,y:33950,ptovrint:False,ptlb:Fade Out Emission,ptin:_FadeOutEmission,varname:node_5895,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Power,id:5671,x:31878,y:31534,varname:node_5671,prsc:2|VAL-1412-RGB,EXP-5816-OUT;proporder:856-9903-8796-8521-5816-9793-3024-5747-1412-9725-8969-5895-6848-9584-3991-9159-8573;pass:END;sub:END;*/

Shader "Wao3DStudio/FX/FadeOut_DoubleSided" {
    Properties {
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _FadeOutColor ("Fade Out Color", Color) = (0.5220588,0.8615618,1,1)
        _SelfIlumination ("Self Ilumination", Float ) = 1
        _Smoothness ("Smoothness", Range(0, 2)) = 0.75
        _AOPower ("AO Power", Range(0, 100)) = 1
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _SpecularMap ("Specular Map", 2D) = "white" {}
        _AOMap ("AO Map", 2D) = "white" {}
        _Alpha ("Alpha", 2D) = "white" {}
        _Fade ("Fade", Range(0, 1)) = 0.5
        _FadeOutEmission ("Fade Out Emission", Float ) = 0
        _LineThikness ("Line Thikness", Range(0, 1)) = 0.1
        [MaterialToggle] _UVActivation ("UV Activation", Float ) = 0.5
        [MaterialToggle] _UVSwich ("UV Swich", Float ) = 0
        [MaterialToggle] _Right_Left ("Right_Left", Float ) = 0
        [MaterialToggle] _Up_Down ("Up_Down", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _DiffuseColor;
            uniform float _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _AOMap; uniform float4 _AOMap_ST;
            uniform float _SelfIlumination;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _Fade;
            uniform float4 _FadeOutColor;
            uniform float _LineThikness;
            uniform fixed _Right_Left;
            uniform fixed _Up_Down;
            uniform fixed _UVSwich;
            uniform fixed _UVActivation;
            uniform float _AOPower;
            uniform float _FadeOutEmission;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 nor = _Normal_var.rgb;
                float3 normalLocal = nor;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(i.uv0, _Alpha));
                float node_2484 = saturate(((pow(((lerp( 0.5, lerp( lerp( i.uv0.r, (1.0 - i.uv0.r), _Right_Left ), lerp( i.uv0.g, (1.0 - i.uv0.g), _Up_Down ), _UVSwich ), _UVActivation )/(1.0 - _Fade))*_Fade),_LineThikness)*2.4+-1.2)-_Alpha_var.r));
                float OAcity = node_2484;
                clip(OAcity - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float Smooth = _Smoothness;
                float gloss = Smooth;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float3 Spec = _SpecularMap_var.rgb;
                float3 specularColor = Spec;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 AL = (UNITY_LIGHTMODEL_AMBIENT.rgb*_LightColor0.rgb);
                indirectDiffuse += AL; // Diffuse Ambient Light
                float4 _AOMap_var = tex2D(_AOMap,TRANSFORM_TEX(i.uv0, _AOMap));
                float3 AO = pow(_AOMap_var.rgb,_AOPower);
                indirectDiffuse *= AO.r; // Diffuse AO
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 Diff = (_DiffuseColor.rgb*_Diffuse_var.rgb*_SelfIlumination);
                float3 diffuseColor = Diff;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 Emm = ((1.0 - node_2484)*_FadeOutEmission*_FadeOutColor.rgb);
                float3 emissive = Emm;
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _DiffuseColor;
            uniform float _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform float _SelfIlumination;
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _Fade;
            uniform float4 _FadeOutColor;
            uniform float _LineThikness;
            uniform fixed _Right_Left;
            uniform fixed _Up_Down;
            uniform fixed _UVSwich;
            uniform fixed _UVActivation;
            uniform float _FadeOutEmission;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 nor = _Normal_var.rgb;
                float3 normalLocal = nor;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(i.uv0, _Alpha));
                float node_2484 = saturate(((pow(((lerp( 0.5, lerp( lerp( i.uv0.r, (1.0 - i.uv0.r), _Right_Left ), lerp( i.uv0.g, (1.0 - i.uv0.g), _Up_Down ), _UVSwich ), _UVActivation )/(1.0 - _Fade))*_Fade),_LineThikness)*2.4+-1.2)-_Alpha_var.r));
                float OAcity = node_2484;
                clip(OAcity - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float Smooth = _Smoothness;
                float gloss = Smooth;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float3 Spec = _SpecularMap_var.rgb;
                float3 specularColor = Spec;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 Diff = (_DiffuseColor.rgb*_Diffuse_var.rgb*_SelfIlumination);
                float3 diffuseColor = Diff;
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform float _Fade;
            uniform float _LineThikness;
            uniform fixed _Right_Left;
            uniform fixed _Up_Down;
            uniform fixed _UVSwich;
            uniform fixed _UVActivation;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(i.uv0, _Alpha));
                float node_2484 = saturate(((pow(((lerp( 0.5, lerp( lerp( i.uv0.r, (1.0 - i.uv0.r), _Right_Left ), lerp( i.uv0.g, (1.0 - i.uv0.g), _Up_Down ), _UVSwich ), _UVActivation )/(1.0 - _Fade))*_Fade),_LineThikness)*2.4+-1.2)-_Alpha_var.r));
                float OAcity = node_2484;
                clip(OAcity - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
