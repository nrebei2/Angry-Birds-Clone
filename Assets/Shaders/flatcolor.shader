// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader"Custom/FlatColor"
{
	Properties
	{
		_Color("Color", Color) = (1.0,1.0,1.0,1.0)
	}
	SubShader
	{
		Pass
		{
			Tags{"LightMode" = "ForwardBase"}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _Color;

			struct vertIn
			{
				float4 vertex : POSITION;
			};
			struct vertOut
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};

			vertOut vert (vertIn i)
			{
				vertOut o;
				o.pos = UnityObjectToClipPos(i.vertex);
				o.col = _Color;

				return o;
			}
			float4 frag (vertOut o) : COLOR
			{
				return o.col;
			}

			ENDCG
		}
	}
	Fallback "Diffuse"
}
