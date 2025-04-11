Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float2 uv = i.uv;

                // --- Gradient logic ---
                float t = abs(uv.x - 0.5) * 2.0;

                float3 green = float3(0.0f, 1.0f, 0.0f);
                float3 orange = float3(1.0f, 0.5f, 0.0f);
                float3 red = float3(1.0f, 0.0f, 0.0f);

                float3 color;
                if (t < 0.5f)
                    color = lerp(green, orange, t * 2.0f);
                else
                    color = lerp(orange, red, (t - 0.5f) * 2.0f);

                // --- Rounded corners ---
                float radius = 0.25f;
                float2 cornerDist = min(uv, 1.0 - uv);
                float dist = min(cornerDist.x, cornerDist.y);
                float alpha = smoothstep(0.0, radius, dist);

                return fixed4(color, alpha);
            }
            ENDCG
        }
    }
}
