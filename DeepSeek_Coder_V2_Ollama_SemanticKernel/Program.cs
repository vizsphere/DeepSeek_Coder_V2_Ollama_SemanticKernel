using Microsoft.SemanticKernel;

#pragma warning disable SKEXP0070 
var kernelBuilder = Kernel.CreateBuilder()
    .AddOllamaTextGeneration(
       modelId: "deepseek-coder-v2:16b",
       endpoint: new Uri("http://localhost:11434")
    );
#pragma warning restore SKEXP0070 

var kernel = kernelBuilder.Build();

Console.WriteLine("Enter a description for the code generation:");
var description = Console.ReadLine();

var codeGenerationFunction = kernel.CreateFunctionFromPrompt(
    $"{description}"
);

// Execute the function
Console.WriteLine("Generating code...");
var result = await kernel.InvokeAsync(codeGenerationFunction,
    new() { { "description", description } }
);

// Print the result
Console.WriteLine(result.GetValue<string>());


