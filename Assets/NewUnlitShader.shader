Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _Color ( "My Color", Color ) = ( 1, 1, 1, 1 )
    }
    
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                float4 light = normalize(_WorldSpaceLightPos0);
                float value = v.normal.x * light.x + v.normal.y * light.y + v.normal.z * light.z;
                o.color.r = value;
                o.color.g = value;
                o.color.b = value;
                o.color.a = 1;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}
