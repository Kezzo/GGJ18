// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33160,y:32567,varname:node_3138,prsc:2|emission-7619-OUT,clip-6736-OUT;n:type:ShaderForge.SFN_Color,id:344,x:32030,y:32745,ptovrint:False,ptlb:TopColor,ptin:_TopColor,varname:_TopColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1724141,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:1512,x:32030,y:32509,ptovrint:False,ptlb:BottomColor,ptin:_BottomColor,varname:_BottomColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:786,x:32459,y:32864,varname:node_786,prsc:2|A-1512-RGB,B-344-RGB,T-9822-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7815,x:32263,y:32509,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7619,x:32459,y:32630,varname:node_7619,prsc:2|A-7815-OUT,B-786-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2271,x:31182,y:32775,varname:node_2271,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:9174,x:31182,y:33029,varname:node_9174,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4912,x:31626,y:32912,varname:node_4912,prsc:2|A-9313-XYZ,B-9662-XYZ;n:type:ShaderForge.SFN_Slider,id:6866,x:31827,y:33206,ptovrint:False,ptlb:GradientLerp,ptin:_GradientLerp,varname:_GradientLerp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5,max:1.75;n:type:ShaderForge.SFN_Add,id:9822,x:32252,y:33015,varname:node_9822,prsc:2|A-2953-OUT,B-6866-OUT;n:type:ShaderForge.SFN_Transform,id:9313,x:31368,y:32809,varname:node_9313,prsc:2,tffrom:0,tfto:3|IN-2271-XYZ;n:type:ShaderForge.SFN_Transform,id:9662,x:31389,y:33029,varname:node_9662,prsc:2,tffrom:0,tfto:3|IN-9174-XYZ;n:type:ShaderForge.SFN_ObjectScale,id:6607,x:31653,y:32749,varname:node_6607,prsc:2,rcp:True;n:type:ShaderForge.SFN_Multiply,id:2953,x:31853,y:32927,varname:node_2953,prsc:2|A-6607-XYZ,B-4912-OUT;n:type:ShaderForge.SFN_Tex2d,id:4151,x:32528,y:32058,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:_Dissolve,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c7dfe9f82b69ad94da3b1f27cadacbba,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRange,id:7163,x:32571,y:32317,varname:node_7163,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9547-OUT;n:type:ShaderForge.SFN_Slider,id:4917,x:32054,y:32371,ptovrint:False,ptlb:DissolveValue,ptin:_DissolveValue,varname:_DissolveValue,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:9895,x:32775,y:32155,varname:node_9895,prsc:2|A-4151-R,B-7163-OUT;n:type:ShaderForge.SFN_Clamp01,id:6736,x:32875,y:32311,varname:node_6736,prsc:2|IN-9895-OUT;n:type:ShaderForge.SFN_Lerp,id:9547,x:32377,y:32269,varname:node_9547,prsc:2|A-679-OUT,B-7775-OUT,T-4917-OUT;n:type:ShaderForge.SFN_Vector1,id:679,x:32089,y:32005,varname:node_679,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Vector1,id:7775,x:32056,y:32160,varname:node_7775,prsc:2,v1:0.75;proporder:344-1512-7815-6866-4151-4917;pass:END;sub:END;*/

Shader "Shader Forge/BlockLightUp" {
    Properties {
        _TopColor ("TopColor", Color) = (0,0.1724141,1,1)
        _BottomColor ("BottomColor", Color) = (1,0,0,1)
        _Alpha ("Alpha", Float ) = 1
        _GradientLerp ("GradientLerp", Range(-1, 1.75)) = 0.5
        _Dissolve ("Dissolve", 2D) = "white" {}
        _DissolveValue ("DissolveValue", Range(0, 1)) = 0.5
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TopColor;
            uniform float4 _BottomColor;
            uniform float _Alpha;
            uniform float _GradientLerp;
            uniform sampler2D _Dissolve; uniform float4 _Dissolve_ST;
            uniform float _DissolveValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float4 _Dissolve_var = tex2D(_Dissolve,TRANSFORM_TEX(i.uv0, _Dissolve));
                float node_7163 = (lerp(0.25,0.75,_DissolveValue)*2.0+-1.0);
                clip(saturate((_Dissolve_var.r+node_7163)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_Alpha*lerp(_BottomColor.rgb,_TopColor.rgb,((recipObjScale*(mul( UNITY_MATRIX_V, float4(i.posWorld.rgb,0) ).xyz.rgb-mul( UNITY_MATRIX_V, float4(objPos.rgb,0) ).xyz.rgb))+_GradientLerp)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Dissolve; uniform float4 _Dissolve_ST;
            uniform float _DissolveValue;
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
            float4 frag(VertexOutput i) : COLOR {
                float4 _Dissolve_var = tex2D(_Dissolve,TRANSFORM_TEX(i.uv0, _Dissolve));
                float node_7163 = (lerp(0.25,0.75,_DissolveValue)*2.0+-1.0);
                clip(saturate((_Dissolve_var.r+node_7163)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
