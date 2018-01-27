// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7619-OUT;n:type:ShaderForge.SFN_Color,id:344,x:32030,y:32745,ptovrint:False,ptlb:TopColor,ptin:_TopColor,varname:_TopColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1724141,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:1512,x:32030,y:32509,ptovrint:False,ptlb:BottomColor,ptin:_BottomColor,varname:_BottomColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:786,x:32459,y:32864,varname:node_786,prsc:2|A-1512-RGB,B-344-RGB,T-9822-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7815,x:32263,y:32509,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7619,x:32459,y:32630,varname:node_7619,prsc:2|A-7815-OUT,B-786-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2271,x:31612,y:32804,varname:node_2271,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:9174,x:31585,y:32967,varname:node_9174,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4912,x:32030,y:32979,varname:node_4912,prsc:2|A-9313-XYZ,B-9662-XYZ;n:type:ShaderForge.SFN_Slider,id:6866,x:31827,y:33206,ptovrint:False,ptlb:GradientLerp,ptin:_GradientLerp,varname:_GradientLerp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5,max:2;n:type:ShaderForge.SFN_Add,id:9822,x:32240,y:33048,varname:node_9822,prsc:2|A-4912-OUT,B-6866-OUT;n:type:ShaderForge.SFN_Transform,id:9313,x:31813,y:32787,varname:node_9313,prsc:2,tffrom:0,tfto:3|IN-2271-XYZ;n:type:ShaderForge.SFN_Transform,id:9662,x:31789,y:33000,varname:node_9662,prsc:2,tffrom:0,tfto:3|IN-9174-XYZ;proporder:344-1512-7815-6866;pass:END;sub:END;*/

Shader "Shader Forge/BlockLightUp" {
    Properties {
        _TopColor ("TopColor", Color) = (0,0.1724141,1,1)
        _BottomColor ("BottomColor", Color) = (1,0,0,1)
        _Alpha ("Alpha", Float ) = 1
        _GradientLerp ("GradientLerp", Range(-1, 2)) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
////// Lighting:
////// Emissive:
                float3 emissive = (_Alpha*lerp(_BottomColor.rgb,_TopColor.rgb,((mul( UNITY_MATRIX_V, float4(i.posWorld.rgb,0) ).xyz.rgb-mul( UNITY_MATRIX_V, float4(objPos.rgb,0) ).xyz.rgb)+_GradientLerp)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
