using System;
using System.Numerics;
using Xunit;

using static Ez.Numerics.EzMath;
namespace Ez.Numerics.Tests
{
    public class EzMathTests
    {
        [Fact]
        public void EpsilonTest()
        {
            Assert.Equal(Epsilon, float.Epsilon, 12);
        }

        [Fact]
        public void PiTest()
        {
            Assert.Equal(PI, MathF.PI, 5);
        }

        [Fact]
        public void ETest()
        {
            Assert.Equal(E, MathF.E, 5);
        }

        [Fact]
        public void TauTest()
        {
            Assert.Equal(Tau, MathF.Tau, 5);
        }

        [Fact]
        public void Deg2RadTest()
        {
            var one = MathF.Sin(90f * Deg2Rad);
            Assert.Equal(1, one, 5);
        }

        [Fact]
        public void Rad2DegTest()
        {
            const float r90 = 1.5708f;
            var degrees = r90 * Rad2Deg;
            Assert.Equal(90, degrees, 3);
        }

        [Fact]
        public void InvLogE2Test()
        {
            var invNlog2 = 1f / MathF.Log(2);
            Assert.Equal(invNlog2, InvLogE2, 5);
        }

        [Fact]
        public void GammaTest()
        {
            Assert.Equal(2.2f, Gamma, 5);
        }

        [Fact]
        public void InvGamaTest()
        {
            Assert.Equal(1f / 2.2f, InvGamma, 5);
        }

        [Fact]
        public void AbsTest()
        {
            Assert.Equal(10f, Abs(-10f));
        }

        [Fact]
        public void AcosTest()
        {
            var rads = 90 * Deg2Rad;
            var cos = MathF.Cos(rads);
            Assert.Equal(rads, Acos(cos), 5);
        }

        [Fact]
        public void ApproximatelyTest()
        {
            var v1 = 1f / 3f;
            var v2 = v1 / 11f;
            Assert.True(Approximately(v1, v2 * 11f));
        }

        [Fact]
        public void AsinTest()
        {
            var rads = 45 * Deg2Rad;
            var sin = MathF.Sin(rads);
            Assert.Equal(rads, Asin(sin), 5);
        }

        [Fact]
        public void AtanTest()
        {
            var rads = 30 * Deg2Rad;
            var tan = MathF.Tan(rads);
            Assert.Equal(rads, Atan(tan), 5);
        }

        [Fact]
        public void Atan2Test()
        {
            var x = 1f;
            var y = 0f;
            var rads = 90f * Deg2Rad;
            Assert.Equal(rads, Atan2(x, y), 5);
        }

        [Fact]
        public void CeilingTest()
        {
            var value = 11.1f;
            Assert.Equal(12f, Ceiling(value), 5);
        }

        [Fact]
        public void ClampTest()
        {
            var min = 5f;
            var max = 10f;
            var value = 11f;
            Assert.Equal(10f, Clamp(value, min, max), 5);
        }

        [Fact]
        public void Clamp01Test()
        {
            var value = 2f;
            Assert.Equal(1f, Clamp01(value), 5);
            Assert.Equal(0f, Clamp01(-value), 5);
        }

        [Fact]
        public void CosTest()
        {
            var rads = 30f * Deg2Rad;
            var cos = MathF.Cos(rads);
            Assert.Equal(cos, Cos(rads), 5);
        }

        [Fact]
        public void DeltaAngleTest()
        {
            Assert.Equal(45f, DeltaAngle(90f, 45f), 5);
            Assert.Equal(180f, DeltaAngle(0f, 180f), 5);
            Assert.Equal(90f, DeltaAngle(0f, 270f), 5);
        }

        [Fact]
        public void ExpTest()
        {
            Assert.Equal(MathF.Exp(5f), Exp(5f), 5);
        }

        [Fact]
        public void FloorTest()
        {
            Assert.Equal(10f, Floor(10.5f), 5);
        }

        [Fact]
        public void GammaToLinearSpaceTest()
        {
            var gamma = 0.5f;
            var linear = MathF.Pow(0.5f, 2.2f);
            Assert.Equal(linear, GammaToLinearSpace(gamma), 5);
        }

        [Fact]
        public void InverseLerpTest()
        {
            var start = 2;
            var end = 7;
            var value = 4.5f;
            Assert.Equal(0.5f, InverseLerp(start, end, value), 5);
        }

        [Fact]
        public void LerpTest()
        {
            var start = 3f;
            var end = 5f;
            Assert.Equal(3.5f, Lerp(start, end, 0.25f), 5);
            Assert.Equal(start, Lerp(start, end, -1), 5);
            Assert.Equal(end, Lerp(start, end, 2), 5);
        }

        [Fact]
        public void LerpUnclampedTest()
        {
            var start = 3f;
            var end = 5f;
            Assert.Equal(3.5f, LerpUnclamped(start, end, 0.25f), 5);
            Assert.NotEqual(start, LerpUnclamped(start, end, -1), 5);
            Assert.NotEqual(end, LerpUnclamped(start, end, 2), 5);
        }

        [Fact]
        public void LinearToGammaSpaceTest()
        {
            var linear = 0.5f;
            var gamma = MathF.Pow(linear, 1f / 2.2f);
            Assert.Equal(gamma, LinearToGammaSpace(linear), 5);
        }

        [Fact]
        public void LogTest1()
        {
            var value = 5;
            var loge = MathF.Log(value);
            Assert.Equal(loge, Log(value), 5);
        }

        [Fact]
        public void LogTest2()
        {
            var x = 5;
            var b = 4;
            var logb = MathF.Log(x, b);
            Assert.Equal(logb, Log(x, b), 5);
        }

        [Fact]
        public void Log10Test()
        {
            var value = 3;
            var log10 = MathF.Log10(value);
            Assert.Equal(log10, Log10(value), 5);
        }

        [Fact]
        public void Log2Test()
        {
            var value = 5;
            var log2 = MathF.Log2(value);
            Assert.Equal(log2, Log2(value), 5);
        }

        [Fact]
        public void MaxTest()
        {
            var max = MathF.Max(-1, 1);
            Assert.Equal(max, Max(-1, 1), 1);
        }

        [Fact]
        public void MinTest()
        {
            var min = MathF.Min(-1, 1);
            Assert.Equal(min, Min(-1, 1), 1);
        }

        [Fact]
        public void PowTest()
        {
            var pow = MathF.Pow(-5, 2);
            Assert.Equal(pow, Pow(-5, 2), 1);
        }

        [Fact]
        public void RoundTest()
        {
            var round = MathF.Round(1.5f);
            Assert.Equal(round, Round(1.5f), 1);
        }

        [Fact]
        public void SignTest()
        {
            Assert.Equal(-1f, Sign(-7), 1);
            Assert.Equal(1f, Sign(-8), 1);
        }

        [Fact]
        public void SqrtTest()
        {
            Assert.Equal(MathF.Sqrt(7f), Sqrt(7f), 5);
        }

        [Fact]
        public void TanTest()
        {
            var rad = 45f * Deg2Rad;
            var tan = MathF.Tan(rad);
            Assert.Equal(tan, Tan(rad), 5);
        }

        [Fact]
        public void EulerAnglesTest()
        {
            var euler = new Vector3(10, 15, 30);
            var quat = euler.ToQuaternion();
            var resultEuler = quat.ToEulerAngles();
            var resultQuat = resultEuler.ToQuaternion();

            Assert.Equal(euler.X, resultEuler.X, 5);
            Assert.Equal(euler.Y, resultEuler.Y, 5);
            Assert.Equal(euler.Z, resultEuler.Z, 5);

            Assert.Equal(quat.X, resultQuat.X, 5);
            Assert.Equal(quat.Y, resultQuat.Y, 5);
            Assert.Equal(quat.Z, resultQuat.Z, 5);
            Assert.Equal(quat.W, resultQuat.W, 5);
        }

        [Fact]
        public void RemapTest()
        {
            var fromMin = 1f;
            var fromMax = 3f;
            var toMin = 2f;
            var toMax = 5f;
            var value = 1.5f;
            Assert.Equal(2.75f, Remap(value, fromMin, fromMax, toMin, toMax), 5);
        }
    }
}