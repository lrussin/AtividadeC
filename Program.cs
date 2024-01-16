//ACELERA.NET 2023/24
//MÓDULO 8 - Programação em C#
//Professor: Flavio Siqueira - flaviosiqueira@outlook.com

//A aplicação console abaixo implementa:
// Tipos de Variáveis: Int, String, Char, Double, Double[]
// Estrutura de decisão
// Estrutura condicional
// Funções de Escrita e Leitura em Console
// Funções/Métodos com e sem parametros

///////////////////////////////////////////////////////
//--------------------NECESSÁRIO---------------------//
//-----***IMPLEMENTAR LAÇO FOR E WHILE/DO WHILE------//
///////////////////////////////////////////////////////


char calcula;


do
{
    Console.WriteLine("***********************************************");
    Console.WriteLine("**        CALCULADORA MEGA ULTRA 2.0         **");
    Console.WriteLine("***********************************************");
    Console.WriteLine("**   Seja bem vindos amigos do ACELERA.NET   **");
    Console.WriteLine("***********************************************");
    Console.WriteLine("");
    Console.WriteLine("Escolha o calculo que deseja:");
    Console.WriteLine("");
    Console.WriteLine("1 - CALCULAR MÉDIA DE NOTAS");
    Console.WriteLine("2 - CALCULAR IMC");
    Console.WriteLine("");
    Console.Write("Opção: ");

    int opcao = (Convert.ToInt32(Console.ReadLine()));
    switch (opcao)
    {
        case 1:
            calculaMedia();
            break;
        case 2:
            calculaIMC();
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.Write("Deseja fazer outro cálculo? (S/N): ");
    calcula = Convert.ToChar(Console.ReadLine());

    if (calcula != 'S' && calcula != 's' && calcula != 'N' && calcula != 'n')
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        Console.Write("Deseja fazer outro cálculo? (S/N): ");
        calcula = Convert.ToChar(Console.ReadLine());
    }
    Console.Clear();

} while (calcula == 'S' || calcula == 's');

void calculaIMC()
{
    Console.Write("Digite o nome: ");
    string nome = Console.ReadLine();

    Console.Write("Digite o peso (kg): ");
    double peso = Convert.ToDouble(Console.ReadLine());

    Console.Write("Digite a altura (cm): ");
    double altura = Convert.ToDouble(Console.ReadLine());

    Console.Write("Digite a idade: ");
    double idade = Convert.ToDouble(Console.ReadLine());

    double IMC = peso / (altura * altura);

    //***CALCULE O IMC DA PESSOA, UTILIZANDO A FÓRMULA...
    //IMC = PESO / ALTURA² (Altura em metros) 

    Console.WriteLine("");
    Console.WriteLine($"O IMC de {nome} é: " + IMC);

    Console.WriteLine("Classificação: " + classificaIMC(IMC));
}

string classificaIMC(double iMC)
{
    string classificacao = "Não classificado";


    if (iMC < 18.5)
    {
        classificacao = "Magreza";
    }
    else if (iMC >= 18.5 && iMC < 24.9)
    {
        classificacao = "Normal";
    }
    else if (iMC >= 25.0 && iMC < 29.9)
    {
        classificacao = "Sobrepeso";
    }
    else if (iMC >= 30.0 && iMC < 39.9)
    {
        classificacao = "Obesidade";
    }
    else if (iMC >= 40.0)
    {
        classificacao = "Obesidade Grave";
    }

    return classificacao;
}

void calculaMedia()
{
    double[] notas = new double[3];
    Console.WriteLine("Digite a primeira nota:");
    notas[0] = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Digite a segunda nota:");
    notas[1] = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Digite a terceira nota:");
    notas[2] = Convert.ToDouble(Console.ReadLine());

    double media = (notas[0] + notas[1] + notas[2]) / 3;

    Console.WriteLine("O aluno foi " + verificaAprovacao(media));

    Console.WriteLine("Média: " + media);
}

string verificaAprovacao(double media)
{
    if (media >= 0 && media <= 10)
    {
        
   
        if (media < 5)
        {
            return "Foi Reprovado";
        }
        else if (media >= 5 && media < 7) 
        {
            return "Está em Recuperação";
        }
        else if (media >= 7)
        { 
            return "Foi Aprovado";
        }
    }
    return "Valor inválido. A nota deve estar entre 0 e 10.";

    //***IMPLEMENTE AQUI O CÓDIGO PARA VERIFICAR SE O ALUNO FOI APROVADO
    //Se media menor que 5 = REPROVADO
    //Se media maior que 5 e menor que 7 = RECUPERAÇÃO
    //Se media maior ou igual a 7 = APROVADO
}

