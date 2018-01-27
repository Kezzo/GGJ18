// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33160,y:32567,varname:node_3138,prsc:2|emission-7619-OUT;n:type:ShaderForge.SFN_Color,id:344,x:32519,y:32755,ptovrint:False,ptlb:TopColor,ptin:_TopColor,varname:_TopColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9310346,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:1512,x:32519,y:32519,ptovrint:False,ptlb:BottomColor,ptin:_BottomColor,varname:_BottomColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2867647,c2:0.1720588,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:786,x:32948,y:32874,varname:node_786,prsc:2|A-1512-RGB,B-344-RGB,T-7567-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7815,x:32752,y:32519,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7619,x:32948,y:32640,varname:node_7619,prsc:2|A-7815-OUT,B-786-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2271,x:31671,y:32785,varname:node_2271,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:9174,x:31671,y:33039,varname:node_9174,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4912,x:32115,y:32922,varname:node_4912,prsc:2|A-2271-Y,B-9174-Y;n:type:ShaderForge.SFN_Add,id:9822,x:32576,y:33041,varname:node_9822,prsc:2|A-2953-OUT,B-3921-OUT;n:type:ShaderForge.SFN_ObjectScale,id:6607,x:32142,y:32749,varname:node_6607,prsc:2,rcp:True;n:type:ShaderForge.SFN_Multiply,id:2953,x:32342,y:32937,varname:node_2953,prsc:2|A-6607-Y,B-4912-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4599,x:32100,y:33301,ptovrint:False,ptlb:Power,ptin:_Power,varname:_Power,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Multiply,id:3921,x:32390,y:33157,varname:node_3921,prsc:2|A-3124-T,B-4599-OUT;n:type:ShaderForge.SFN_Cos,id:7567,x:32800,y:33040,varname:node_7567,prsc:2|IN-9822-OUT;n:type:ShaderForge.SFN_Time,id:3124,x:32008,y:33060,varname:node_3124,prsc:2;proporder:344-1512-7815-4599;pass:END;sub:END;*/

Shader "Custom/EnergyPulseY" {
    Properties {
        _TopColor ("TopColor", Color) = (1,0.9310346,0,1)
        _BottomColor ("BottomColor", Color) = (0.2867647,0.1720588,0,1)
        _Alpha ("Alpha", Float ) = 1
        _Power ("Power", Float ) = 8
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
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 2.0
            uniform float4 _TopColor;
            uniform float4 _BottomColor;
            uniform float _Alpha;
            uniform float _Power;
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
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
////// Lighting:
////// Emissive:
                float4 node_3124 = _Time;
                float3 emissive = (_Alpha*lerp(_BottomColor.rgb,_TopColor.rgb,cos(((recipObjScale.g*(i.posWorld.g-objPos.g))+(node_3124.g*_Power)))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
