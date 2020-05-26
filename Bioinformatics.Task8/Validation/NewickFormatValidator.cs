using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bioinformatics.Task8.Validation
{
	/// <summary>
	/// Валидатор формата Newick.
	/// </summary>
	internal static class NewickFormatValidator
	{
		private enum ValidatorState : byte
		{
			NodeNameHandling,
			NodeWeightHandling,
			WaitForAnotherNode
		}

		/// <summary>
		/// Произвести валидацию строки в формате Newick.
		/// </summary>
		public static ValidationResult ValidateNewickString(string newickString)
		{
			if (newickString[^1] != Constants.EndSymbol)
			{
				return ValidationResult.InvalidEndSymbol;
			}

			var bracketsCount = 0;

			var foundNodeNames = new HashSet<string>();

			var currentState = ValidatorState.NodeNameHandling;
			var currentNode = new StringBuilder();
			var currentNumber = new StringBuilder();

			foreach (var character in newickString.SkipLast(1))
			{
				if (character == '(')
				{
					if (currentState == ValidatorState.NodeWeightHandling) return ValidationResult.InvalidNodeWeight;
					bracketsCount++;
					continue;
				}

				if (character == ')')
				{
					bracketsCount--;
					if (bracketsCount < 0) return ValidationResult.ImbalancedBrackets;

					if (currentState == ValidatorState.NodeNameHandling || currentState == ValidatorState.NodeWeightHandling)
					{
						if (currentState == ValidatorState.NodeNameHandling && currentNode.Length > 0)
						{
							if (foundNodeNames.Contains(currentNode.ToString()))
							{
								return ValidationResult.NodeNameDuplicate;	
							}
							foundNodeNames.Add(currentNode.ToString());
							currentNode.Clear();
						}

						currentNumber.Clear();
						currentState = ValidatorState.NodeNameHandling;
					}
					continue;
				}

				switch (currentState)
				{
					case ValidatorState.NodeNameHandling:
					{
						if (Constants.InvalidNodeChars.Contains(character) || char.IsDigit(character))
						{
							return ValidationResult.InvalidNodeName;
						}

						if (character == Constants.NodeSeparator || character == Constants.NameWeightSeparator)
						{
							currentState = character == Constants.NameWeightSeparator
								? ValidatorState.NodeWeightHandling
								: ValidatorState.WaitForAnotherNode;

							if (currentNode.Length > 0)
							{
								if (foundNodeNames.Contains(currentNode.ToString()))
								{
									return ValidationResult.NodeNameDuplicate;
								}
								foundNodeNames.Add(currentNode.ToString());
							}

							currentNode.Clear();
							if (currentState == ValidatorState.NodeWeightHandling)
							{
								break;
							}
						}
						
						if (!char.IsDigit(character) && !Constants.InvalidNodeChars.Contains(character))
						{
							currentNode.Append(character);
						}

						break;
					}

					case ValidatorState.NodeWeightHandling:
					{
						if (Constants.InvalidWeightChars.Contains(character)) return ValidationResult.InvalidNodeWeight;

						if (character == Constants.NodeSeparator)
						{
							currentState = ValidatorState.WaitForAnotherNode;
							currentNumber.Clear();
							break;
						}

						if (char.IsDigit(character) || character == '.') 
						{
							if (character == '.' 
							    && (currentNumber.ToString().Contains(".") || currentNumber.Length == 0))
							{
								return ValidationResult.InvalidNodeWeight;
							}

							if (character != '.' 
							    && currentNumber.Length == 1 
							    && currentNumber[0] == '0') 
							{
								return ValidationResult.InvalidNodeWeight;
							}

							currentNumber.Append(character);
							break;
						}

						if (char.IsLetter(character)) return ValidationResult.InvalidNodeWeight;
						break;
					}

					case ValidatorState.WaitForAnotherNode:
					{
						if (character == Constants.NodeSeparator || character == ' ')
						{
							break;
						}

						if (char.IsDigit(character) || Constants.InvalidNodeChars.Contains(character))
						{
							return ValidationResult.InvalidNodeName;
						}

						currentState = ValidatorState.NodeNameHandling;
						currentNode.Append(character);
						break;
					}

					default: throw new ArgumentOutOfRangeException();
				}
			}

			return bracketsCount == 0
				? ValidationResult.Success
				: ValidationResult.ImbalancedBrackets;
		}
	}
}