using System.Linq;

namespace Bioinformatics.Task1
{
	internal static class RnaSequenceExtensions
	{
		public static string Translate(this RnaSequence rnaSequence)
		{
			var tokens = rnaSequence.Values.Select(Translate);
			return string.Join(' ', rnaSequence);
		}
		
		private static string Translate(string stringValue)
		{
			return stringValue switch
			{
				"TTT" => "Phe",
				"TTC" => "Phe",
				"TTA" => "Leu",
				"TTG" => "Leu",
				"TCT" => "Ser",
				"TCC" => "Ser",
				"TCA" => "Ser",
				"TCG" => "Ser",
				"TAT" => "Tyr",
				"TAC" => "Tyr",
				"TAA" => "",
				"TAG" => "",
				"TGT" => "Cys",
				"TGC" => "Cys",
				"TGA" => "",
				"TGG" => "",

				"CTT" => "Leu",
				"CTC" => "Leu",
				"CTA" => "Leu",
				"CTG" => "Leu",
				"CCT" => "Pro",
				"CCC" => "Pro",
				"CCA" => "Pro",
				"CCG" => "Pro",
				"CAT" => "His",
				"CAC" => "His",
				"CAA" => "Gln",
				"CAG" => "Gln",
				"CGT" => "Arg",
				"CGC" => "Arg",
				"CGA" => "Arg",
				"CGG" => "Arg",

				"ATT" => "Ile",
				"ATC" => "Ile",
				"ATA" => "Ile",
				"ATG" => "Met",
				"ACT" => "Thr",
				"ACC" => "Thr",
				"ACA" => "Thr",
				"ACG" => "Thr",
				"AAT" => "Asn",
				"AAC" => "Asn",
				"AAA" => "Lys",
				"AAG" => "Lys",
				"AGT" => "Ser",
				"AGC" => "Ser",
				"AGA" => "Arg",
				"AGG" => "Arg", 
				
				"GTT" => "Val",
				"GTC" => "Val",
				"GTA" => "Val",
				"GTG" => "Val",
				"GCT" => "Ala",
				"GCC" => "Ala",
				"GCA" => "Ala",
				"GCG" => "Ala",
				"GAT" => "Asp",
				"GAC" => "Asp",
				"GAA" => "Glu",
				"GAG" => "Glu",
				"GGT" => "Gly",
				"GGC" => "Gly",
				"GGA" => "Gly",
				"GGG" => "Gly",
				_ => ""
			};
		}
	}
}