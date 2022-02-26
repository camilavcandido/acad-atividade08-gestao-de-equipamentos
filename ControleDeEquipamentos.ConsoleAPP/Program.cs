﻿using System;

namespace ControleDeEquipamentos.ConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //variaveis
            string opcaoMenu;
            string continuar;
            string[] nomeEquipamento = new string[1000];
            string[] numeroSerie = new string[1000];
            decimal[] precoEquipamento = new decimal[1000];
            string[] dataFabricacao = new string[1000];
            string[] nomeFabricante = new string[1000];
            bool[] temChamado = new bool[1000];
            int indice = 0;
            //variaveis chamado
            int[] idChamado = new int[1000];
            string[] tituloChamado = new string[1000];
            string[] descricaoChamado = new string[1000];
            string[] dataAberturaChamado = new string[1000];
            int indiceChamado = 0;
            int geraid = 1;
            bool[] statusChamado = new bool[1000];

            do
            {

                opcaoMenu = ApresentaMenu();

                switch (opcaoMenu)
                {
                    case "1":
                        do
                        {
                            continuar = RegistraEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado, ref indice);
                        } while (continuar == "S");
                        Console.Clear();
                        break;
                    case "2":
                        ExibeEquipamentosRegistrados(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado, ref indice);
                        break;
                    case "3":
                        EditaEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado);
                        break;
                    case "4":
                        ExcluiEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado);
                        break;
                    case "5":
                        RegistrarChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref geraid, ref statusChamado);
                        break;
                    case "6":
                        ExibeChamados(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "7":
                        EditaChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado);
                        break;
                    case "8":
                        ExcluiChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "9":
                        ExibeChamadosExcluidos(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "10":
                        Environment.Exit(0);
                        break;
                }


            } while (1 == 1);


            #region metodos
            static string ApresentaMenu()
            {
                string opcaoMenu;
                TituloMenu();
                Console.WriteLine("" +
                    "\t1 - Registrar Novo Equipamento\n" +
                    "\t2 - Visualizar os Equipamentos Registrados\n" +
                    "\t3 - Editar Equipamento\n" +
                    "\t4 - Excluir Equipamento\n" +
                    "\t5 - Registrar Chamado de Manutenção\n" +
                    "\t6 - Visualizar os Chamados Registrados\n" +
                    "\t7 - Editar Chamado\n" +
                    "\t8 - Excluir Chamado\n" +
                    "\t9 - Visualizar Chamados Excluidos\n" +
                    "\t10 - Sair");
                ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);
                opcaoMenu = Console.ReadLine();
                while (opcaoMenu != "1" && opcaoMenu != "2" && opcaoMenu != "3" && opcaoMenu != "4" &&
                    opcaoMenu != "5" && opcaoMenu != "6" && opcaoMenu != "7" && opcaoMenu != "8" && opcaoMenu != "9" && opcaoMenu != "10")
                {
                    ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                    ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);
                    opcaoMenu = Console.ReadLine();
                }
                return opcaoMenu;
            }

            static string RegistraEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado, ref int indice)
            {
                string continuar;

                TituloSecao("1 - Registrar Novo Equipamento");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Nome:");
                nomeEquipamento[indice] = Console.ReadLine();
                VerificaQuantidadeCaracteres(ref nomeEquipamento, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Número de Série:");
                numeroSerie[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Preço:");
                precoEquipamento[indice] = decimal.Parse(Console.ReadLine());
                VerificaPrecoEhPositivo(ref precoEquipamento, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Data de Fabricação\n");
                RecebeEValidaEntradaDataFabricacao(ref dataFabricacao, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Fabricante:");
                nomeFabricante[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                temChamado[indice] = false;

                indice++;


                ApresentaMensagem("\n\tEquipamento registrado com sucesso!", ConsoleColor.Green);


                Console.WriteLine("\n\tDeseja registrar outro equipamento? Digite S para sim ou N para não");
                ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);

                continuar = Console.ReadLine();

                return continuar;
            }

            static void VerificaQuantidadeCaracteres(ref string[] nomeEquipamento, ref int indice)
            {
                while (nomeEquipamento[indice].Length < 6)
                {
                    ApresentaMensagem("O nome do equipamento deve possuir no minimo 6 caracteres", ConsoleColor.Red);
                    NomeInput("Digite o Nome:");

                    nomeEquipamento[indice] = Console.ReadLine().ToLower();
                }
            }

            static void ExibeEquipamentosRegistrados(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado, ref int indice)
            {

                TituloSecao("2 - Visualizar os Equipamentos Registrados");
                ImprimeLinhaEmBranco();


                if (indice == 0)
                {

                    ApresentaMensagem("Não há equipamentos registrados. Digite qualquer tecla para retornar ao menu", ConsoleColor.Red);

                }
                else
                {


                    for (int i = 0; i < indice; i++)
                    {
                        if (numeroSerie[i] != null)
                        {
                            Console.WriteLine();

                            string espaco = "        ";

                            teste("Nome: ");
                            Console.Write(nomeEquipamento[i]+ espaco);
                            teste("Nº Série: ");
                            Console.Write(numeroSerie[i]+ espaco);
                            teste("Fabricante: ");
                            Console.Write(nomeFabricante[i]+ espaco);
                            teste("Tem chamado: ");
                            Console.Write(temChamado[i]);

                            Console.WriteLine();
                        }


                    }
                    ApresentaMensagem("\n\tListagem de equipamentos finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();
            }

            static void EditaEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {
                TituloSecao("3 - Editar Equipamento");
                ImprimeLinhaEmBranco();


                NomeInput("Digite o Nº de Série do equipamento que deseja editar:");
                string numeroSerieEditar = Console.ReadLine();
                bool numeroSerieExiste = false;

                ImprimeLinhaEmBranco();

                for (int i = 0; i < numeroSerie.Length; i++)
                {

                    if (numeroSerieEditar == numeroSerie[i]) //quando encontrar o numeroSerie igual o digitado, apresenta os campos para editar o equip.
                    {
                        numeroSerieExiste = true;

                        ApresentaMensagem("Editando Equipamento Nº Série = " + numeroSerie[i], ConsoleColor.Blue);

                        NomeInput("Digite o novo Nome:");

                        int indice = i;
                        nomeEquipamento[indice] = Console.ReadLine();

                        VerificaQuantidadeCaracteres(ref nomeEquipamento, ref indice);

                        ImprimeLinhaEmBranco();
                        NomeInput("Digite o novo Número de Série:");
                        numeroSerie[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Preço:");
                        precoEquipamento[i] = decimal.Parse(Console.ReadLine());
                        VerificaPrecoEhPositivo(ref precoEquipamento, ref indice);
                        ImprimeLinhaEmBranco();


                        NomeInput("Data de Fabricação (dd/mm/aaaa):");
                        RecebeEValidaEntradaDataFabricacao(ref dataFabricacao, ref indice);
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Fabricante:");
                        nomeFabricante[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();


                        ApresentaMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);

                    }

                }
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);

                }

                Console.ReadLine();

            }

            static void ExcluiEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {
                //variaveis
                string numeroSerieSelecionado, confirmacao;
                bool numeroSerieExiste = false;

                TituloSecao("4 - Excluir Equipamento");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o número de série do equipamento que deseja excluir:");
                numeroSerieSelecionado = Console.ReadLine();

                for (int i = 0; i < numeroSerie.Length; i++)
                {
                    //não permite exclusão caso o equipamento possua chamado em aberto
                    if (numeroSerie[i] == numeroSerieSelecionado)
                    {
                        numeroSerieExiste = true;

                        if (temChamado[i] == true)
                        {
                            ApresentaMensagem("Não é possível excluir o equipamento que possuí chamado em aberto.", ConsoleColor.Red);
                        }
                        else if (temChamado[i] == false)
                        {

                            ApresentaMensagem("Deseja remover o equipamento com Nº de série " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                            confirmacao = Console.ReadLine();
                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                                ApresentaMensagem("Deseja remover o equipamento com Nº de série " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                                confirmacao = Console.ReadLine();
                            }

                            if (confirmacao == "S")
                            {
                                nomeEquipamento[i] = null;
                                numeroSerie[i] = null;
                                precoEquipamento[i] = 0;
                                dataFabricacao[i] = null;
                                nomeFabricante[i] = null;
                                ApresentaMensagem("Equipamento removido!", ConsoleColor.Green);
                            }
                            else if (confirmacao == "N")
                            {
                                ApresentaMensagem("Operação cancelada!", ConsoleColor.Yellow);

                            }
                        }
                    }
                }

                //caso numero de serie inexistente, apresenta mensagem
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);

                }

                Console.ReadLine();
            }

            static void RegistrarChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref int geraid, ref bool[] statusChamado)
            {
                string numeroSerieSelecionado;
                bool numeroSerieExiste = false;

                TituloSecao("5 - Registrar Chamado de Manutenção");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Número de Série do Equipamento:");
                numeroSerieSelecionado = Console.ReadLine();
                ImprimeLinhaEmBranco();



                for (int i = 0; i < numeroSerie.Length; i++)
                {
                    //não permite exclusão caso o equipamento possua chamado em aberto
                    if (numeroSerie[i] == numeroSerieSelecionado)
                    {

                        numeroSerieExiste = true;

                        NomeInput("Digite o Título do Chamado:");

                        tituloChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a Descrição do Chamado:");
                        descricaoChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a Data de Abertura do Chamado (dd/mm/aaaa):");
                        dataAberturaChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();


                        idChamado[indiceChamado] = geraid;

                        temChamado[i] = true;

                        statusChamado[i] = true;

                        indiceChamado++;

                        ApresentaMensagem("Chamado registrado com sucesso!", ConsoleColor.Green);

                        geraid++;
                        Console.ReadLine();
                    }

                }
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);
                    Console.ReadLine();
                }

            }

            static void ExibeChamados(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                TituloSecao("6 - Visualizar os Chamados Registrados");
                ImprimeLinhaEmBranco();

                if (indiceChamado == 0)
                {
                    ApresentaMensagem("Não há chamados registrados!", ConsoleColor.Red);
                    Console.ReadLine();

                }

                else
                {
                    for (int i = 0; i < indiceChamado; i++)
                    {
                        if (statusChamado[i] == true)
                        {
                            Console.WriteLine("____________________");
                            Console.WriteLine("ID chamado:" + idChamado[i]);
                            Console.WriteLine("Titulo Chamado: " + tituloChamado[i]);
                            Console.WriteLine("Nº Série Equipamento: " + numeroSerie[i]);
                            Console.WriteLine("Descrição do Chamado: " + descricaoChamado[i]);
                            Console.WriteLine("Data de Abertura: " + dataAberturaChamado[i]);

                            string strData = dataAberturaChamado[i];
                            DateTime DateObject = Convert.ToDateTime(strData);
                            TimeSpan diasEmAberto = DateTime.Today - DateObject;

                            Console.WriteLine("Dias em aberto: " + diasEmAberto.TotalDays);
                            Console.WriteLine("____________________");

                        }
                    }
                    ApresentaMensagem("\n\tListagem de chamados finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();

            }

            static void EditaChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado)
            {
                bool chamadoExiste = false;
                bool numeroSerieExiste = false;
                string numeroSerieSelecionado;
                TituloSecao("7 - Editar Chamado");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o indice do chamado que deseja editar:");
                int chamadoSelecionado = int.Parse(Console.ReadLine());

                for (int i = 0; i < idChamado.Length; i++)
                {

                    if (chamadoSelecionado == idChamado[i]) //quando encontrar o numeroSerie igual o digitado, apresenta os campos para editar o equip.
                    {
                        chamadoExiste = true;
                        ApresentaMensagem("Editando Chamado ID = " + idChamado[i], ConsoleColor.Blue);

                        NomeInput("Digite o Número de Série do Equipamento:");
                        numeroSerieSelecionado = Console.ReadLine();

                        if (numeroSerieSelecionado == numeroSerie[i])
                        {
                            numeroSerieExiste = true;

                            ImprimeLinhaEmBranco();

                            NomeInput("Digite o novo Titulo do Chamado:");
                            tituloChamado[i] = Console.ReadLine();
                            ImprimeLinhaEmBranco();

                            NomeInput("Digite a nova Descrição do Chamado:");
                            descricaoChamado[i] = Console.ReadLine();
                            ImprimeLinhaEmBranco();

                            NomeInput("Digite a nova Data de Abertura do Chamado:");
                            dataAberturaChamado[i] = Console.ReadLine();
                            ImprimeLinhaEmBranco();

                            ApresentaMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
                        }


                    }
                }


                if (chamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado! Verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }

                else if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não existe. Verifique o Nº de Série e tente novamente!", ConsoleColor.Red);

                }

                Console.ReadLine();

            }

            static void ExcluiChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                //variaveis
                int idChamadoSelecionado;
                bool idChamadoExiste = false;
                string confirmacao;

                TituloSecao("8 - Excluir Chamado");


                NomeInput("Digite o ID do Chamado que deseja excluir: ");
                idChamadoSelecionado = int.Parse(Console.ReadLine());

                for (int i = 0; i < idChamado.Length; i++)
                {
                    if (idChamadoSelecionado == idChamado[i])
                    {
                        idChamadoExiste = true;

                        if (statusChamado[i] == true)
                        {
                            ApresentaMensagem("Deseja remover o chamado ID = " + idChamado[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                            confirmacao = Console.ReadLine();
                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                                ApresentaMensagem("Deseja remover o chamado ID = " + idChamado[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);


                                confirmacao = Console.ReadLine();
                            }
                            if (confirmacao == "S")
                            {
                                temChamado[i] = false;
                                statusChamado[i] = false;
                                ApresentaMensagem("Chamado removido com sucesso!", ConsoleColor.Green);
                            }
                            else if (confirmacao == "N")
                            {
                                ApresentaMensagem("Operação cancelada!", ConsoleColor.Yellow);

                            }
                        }


                    }
                }

                if (idChamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado! Verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }
                Console.ReadLine();
            }

            static void VerificaPrecoEhPositivo(ref decimal[] precoEquipamento, ref int indice)
            {
                while (precoEquipamento[indice] <= -0)
                {
                    ApresentaMensagem("O Preço do Equipamento deve ser decimal, positivo e maior que zero", ConsoleColor.Red);
                    NomeInput("Digite o Preço:");
                    precoEquipamento[indice] = decimal.Parse(Console.ReadLine());

                }
            }

            static void ExibeChamadosExcluidos(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                for (int i = 0; i < indiceChamado; i++)
                {
                    if (statusChamado[i] == false)
                    {
                        Console.WriteLine("____________________");
                        Console.WriteLine("ID chamado:" + idChamado[i]);
                        Console.WriteLine("Titulo Chamado: " + tituloChamado[i]);
                        Console.WriteLine("Nº Série Equipamento: " + numeroSerie[i]);
                        Console.WriteLine("Descrição do Chamado: " + descricaoChamado[i]);
                        Console.WriteLine("Data de Abertura: " + dataAberturaChamado[i]);
                        Console.WriteLine("Dias em aberto:");
                        Console.WriteLine("____________________");

                    }
                }

            }

            static void RecebeEValidaEntradaDataFabricacao(ref string[] dataFabricacao, ref int indice)
            {
                NomeInput("Digite o dia (dd):");
                int dia = int.Parse(Console.ReadLine());
                while (dia <= 0 || dia > 31)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 31", ConsoleColor.Red);
                    NomeInput("Digite o dia (dd):");
                    dia = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o mês (mm):");
                int mes = int.Parse(Console.ReadLine());
                while (mes < 1 || mes > 12)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 12", ConsoleColor.Red);
                    NomeInput("Digite o mês (mm):");
                    mes = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o ano (aaaa):");
                int ano = int.Parse(Console.ReadLine());
                while (ano < 2000 || ano > 2022)
                {
                    ApresentaMensagem("É permitido valores entre 2000 e 2022", ConsoleColor.Red);
                    NomeInput("Digite o ano (aaaa):");
                    ano = int.Parse(Console.ReadLine());
                }

                DateTime dataF = new DateTime(ano, mes, dia);

                dataFabricacao[indice] = Convert.ToString(dataF);

                //  Console.WriteLine(dataFabricacao[indice]);
            }



            #endregion

            #region  estilizacao

            static void ApresentaMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.WriteLine("\t" + mensagem);
                Console.ResetColor();
            }

            static void ApresentaMensagemEntradaDeDados(string msg, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.Write(msg);
                Console.ResetColor();

            }

            static void ImprimeLinhaEmBranco()
            {
                Console.WriteLine();
            }

            static void TituloMenu()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Gestão de Equipamentos - Menu ");
                Console.ResetColor();
            }

            static void TituloSecao(string titulo)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t" + titulo);
                Console.ResetColor();
            }

            static void NomeInput(string nome)
            {
                Console.Write("\t" + nome + " ");
            }

            static void teste(string teste)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(teste);
                Console.ResetColor();
            }
            #endregion
        }
    }
}



