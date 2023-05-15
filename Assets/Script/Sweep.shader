Shader "Huse360/Sweep" {
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {}
        _param("Param.", Float) = 0.5
    }
        SubShader{
        Pass {
        CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform float _param;


            float4 frag(v2f_img i) : COLOR{

                float4 color = tex2D(_MainTex, i.uv);
                float saw = i.uv.y * 10;
                saw -= floor(i.uv.y * 10);
                saw = saw > _param;
                return lerp(color, float4(0, 0, 0, 1), saw);
            }
                ENDCG
        }//Pass
        }//SubShader
     }//Shader

