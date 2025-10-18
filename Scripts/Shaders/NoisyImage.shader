Shader "Unlit/NoisyImage"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Noise ("Noise", Range(0,1)) = 0.2
        _Resolution("Resolution", float) = 256.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float noiseFunc(float2 uv, float f)
            {
                return sin(uv.x * f + uv.y * f * 1023.42164);
            }

            float _Noise;
            float _Resolution;

            float4 frag (v2f i) : SV_Target
            {
                float2 id = floor(i.uv * _Resolution);
                // sample the texture
                float4 col = tex2D(_MainTex, id / _Resolution);
                float noise = noiseFunc(id, 134.26412);
                return col * (1 - _Noise) + noise * _Noise * _Noise;
            }
            ENDCG
        }
    }
}
