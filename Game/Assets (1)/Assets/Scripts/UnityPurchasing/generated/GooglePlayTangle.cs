// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("QR2UMBg4WZNZ+rqGjHwnYvt+Ceevch4NdHWjaqo+ifk7GkW5UanuHEYkeN7W+xnsXs6RhJ2xfSswcrfJ3Bt1QiZ5A1EfikVpuuEGcj216roTCWMpMQyciEU61OCNo75DDvcTL4s5upmLtr2ykT3zPUy2urq6vru4wBb741Dvsl0mJMN2bVZZiy1KW1Rpyhsj6gg0gLrOu7MbbtwlvocWgSdb3NeoPe8SIyF8CLdRjk7vK3pv4NyLJ87I7mD5uNQie4qGm9KkLTAzFy57Xtedrj9h+uvx0PK+kBsAX5FcWr5wq1esbbuTlvkH4jYqNpPRnM4kyRvTQd45O0PdNQqMhOvInew5urS7izm6sbk5urq7IcGv4g8CySXh9TZYm1oYXrm4uru6");
        private static int[] order = new int[] { 10,6,12,13,13,10,13,8,12,10,10,11,12,13,14 };
        private static int key = 187;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
