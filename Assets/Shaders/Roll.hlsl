#include "Utlility.hlsl"

void DoRoll_float(float3 vertex, out float3 result)
{
    float3 dir = vertex - _BendingCenter;
    result = _BendingCenter + Unity_RotateAboutAxis_Degrees(dir, _BendAxis, _Spin * vertex.y * _SpinToAttenuated);
}

// vertex.y değeri açıyı ifade ediyor.
// _Spin = Açı katsayısı
// Yayımız ters yöne doğru giderken bozulma oluyor. _SpinToAttenuated değişkeni bunun için. Ufak bir hile.

// ------------------------------------------------------------------------------------------------------------------------

// vertex.y = represents the angle.
// _Spin = Angle coefficient
// There is a distortion when our spring goes in the opposite direction. The _SpinToAttenuated variable is for this. It's a little trick.