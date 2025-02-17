# JSON Calculator

## Description

This C# project reads mathematical operations from a JSON file, performs calculations, and writes the results to an output file. The operations are sorted in ascending order based on their computed values.

## Features

- Supports basic mathematical operations:
  - Addition (`"add"`)
  - Subtraction (`"sub"`)
  - Multiplication (`"mul"`)
  - Square root (`"sqrt"`)
- Reads input from a JSON file (`input.json`).
- Writes results to an output file (`output.txt`).
- Handles errors gracefully.

## Installation

1. Ensure you have [.NET](https://dotnet.microsoft.com/) installed.
2. Clone this repository or download the source code.

## Usage

1. Create an `input.json` file in the project directory with the following format:

```json
{
  "operation1": { "operator": "add", "value1": 10, "value2": 5 },
  "operation2": { "operator": "mul", "value1": 4, "value2": 3 },
  "operation3": { "operator": "sqrt", "value1": 16, "value2": 0 }
}
```

2. Run the program:

```sh
dotnet run
```

3. The results will be saved in `output.txt` in ascending order.

## Error Handling

- If the JSON file is missing or invalid, an error message is displayed.
- If an invalid operator is provided, the program throws an exception.
