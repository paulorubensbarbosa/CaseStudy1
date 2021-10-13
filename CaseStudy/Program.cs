using CaseStudy.Model;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            IOrganizationService service = ConnectionFactury.GetCrmService();
            Opportunity opportunity = new Opportunity(service);

            
            Console.WriteLine("Digite o ID da oportunidade que deseja aplicar o desconto");
            string idDigitado = Console.ReadLine();

            EntityCollection opportunitysCRM = opportunity.RetrieveMultipeContactsByAccount(new Guid(idDigitado));
            
            foreach (Entity opportunityCRM in opportunitysCRM.Entities) 
            {
                
                Money valorTotalOportunidade = (Money)opportunityCRM["totalamount"];
                //valor total da oportunidade
                decimal valorTotal = valorTotalOportunidade.Value ;
                //Console.WriteLine(valorTotal);

                EntityReference tipodeConta = (EntityReference)((AliasedValue)opportunityCRM["conta.fyi_oniveldocliente"]).Value;
                //tipo da conta
                string tipoDaConta = tipodeConta.Name;
                
                string telephonedaconta = ((AliasedValue)opportunityCRM["conta.telephone1"]).Value.ToString();
                
                
                //Console.WriteLine(tipoDaConta);
                //Console.WriteLine(((EntityReference)opportunityCRM["parentaccountid"]).Id);

                if(tipoDaConta.Equals("Diamond"))
                {
                    decimal desconto = 10/100m;
                    decimal resultado = ( valorTotal * desconto ) ;

                    Console.WriteLine("Esse será o valor descontado "+ Math.Round( resultado,2)); 
                    Console.WriteLine("Deseja aplicar esse desconto? Y / N");
                    String opcaoCliente = Console.ReadLine();
                    
                    if(opcaoCliente.Equals("Y"))
                    {
                        opportunity.UpdateOpportunity( resultado, idDigitado );
                        Console.WriteLine("Valor de desconto modificado no Dynamics!!!");
                        
                    }
                    else 
                    {
                        Console.WriteLine("obrigado");
                    }
                    

                }else if(tipoDaConta.Equals("Platinum"))
                {
                    decimal desconto = 7/100m;
                    decimal resultado = ( valorTotal * desconto ) ;

                    Console.WriteLine("Esse será o valor descontado "+ Math.Round( resultado,2)); 
                    Console.WriteLine("Deseja aplicar esse desconto? Y / N");
                    String opcaoCliente = Console.ReadLine();
                    
                    if(opcaoCliente.Equals("Y"))
                    {
                        opportunity.UpdateOpportunity( resultado, idDigitado );
                        Console.WriteLine("Valor de desconto modificado no Dynamics!!!");
                        
                    }
                    else 
                    {
                        Console.WriteLine("obrigado");
                    }

                }else if(tipoDaConta.Equals("Gold"))
                {
                    decimal desconto = 5/100m;
                    decimal resultado = ( valorTotal * desconto ) ;

                    Console.WriteLine("Esse será o valor descontado "+ Math.Round( resultado,2)); 
                    Console.WriteLine("Deseja aplicar esse desconto? Y / N");
                    String opcaoCliente = Console.ReadLine();
                    
                    if(opcaoCliente.Equals("Y"))
                    {
                        opportunity.UpdateOpportunity( resultado, idDigitado );
                        Console.WriteLine("Valor de desconto modificado no Dynamics!!!");
                        
                    }
                    else 
                    {
                        Console.WriteLine("obrigado");
                    }
                }else 
                {
                    decimal desconto = 3/100m;
                    decimal resultado = ( valorTotal * desconto ) ;

                    Console.WriteLine("Esse será o valor descontado "+ Math.Round( resultado,2)); 
                    Console.WriteLine("Deseja aplicar esse desconto? Y / N");
                    String opcaoCliente = Console.ReadLine();
                    
                    if(opcaoCliente.Equals("Y"))
                    {
                        opportunity.UpdateOpportunity( resultado, idDigitado );
                        Console.WriteLine("Valor de desconto modificado no Dynamics!!!");
                        
                    }
                    else 
                    {
                        Console.WriteLine("obrigado");
                    } 
                }
                
                

            
            }
            
          
            Console.ReadKey();
            

            }
        }
    }

