HexToBase64("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");

void HexToBase64(string hex) {
    Console.WriteLine($"Before: '{hex}'");
    var converted = Convert.ToBase64String(Convert.FromHexString(hex));
    Console.WriteLine($"After: '{converted}'");
}
