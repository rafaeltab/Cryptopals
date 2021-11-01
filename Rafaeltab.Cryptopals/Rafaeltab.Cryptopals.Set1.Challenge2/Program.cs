// See https://aka.ms/new-console-template for more information
FixedXOR("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965");

void FixedXOR(string a, string b) {
    if (a.Length == 0 || a.Length != b.Length) {
        throw new ArgumentException($"Invalid input to FixedXOR, either a or b was length 0 or they were different lengths");
    }

    Console.WriteLine($"Calculating XOR off '{a}' and '{b}'");

    var aBytes = Convert.FromHexString(a);
    var bBytes = Convert.FromHexString(b);

    byte[] resBytes = new byte[aBytes.Length];

    for (int i = 0; i < aBytes.Length; i++)
    {
        resBytes[i] = (byte) (aBytes[i] ^ bBytes[i]);
    }

    var res = Convert.ToHexString(resBytes);

    Console.WriteLine($"Result: '{res}'");
}