﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CreditCardProcessor.DataAccessLayer;
using CreditCardProcessor.CreditCardProcess.Constants;
using CreditCardProcessor.BusinessObject;
namespace CreditCardProcess
{
    public class ProcessCreditCard
    {
        private string file = string.Empty;
        private Queue<string> fileDataQueue;
        private CreditCardProcessAccessLayer creditCardProcessAccessLayer = null;
        private int MaxCunter = 10;
        private int counter = 0;
        

        public ProcessCreditCard(string file)
        {
            this.file = file;
            fileDataQueue = new Queue<string>();
            creditCardProcessAccessLayer = new CreditCardProcessAccessLayer();
            
        }

                
        /// <summary>
        /// Reads data from the input file 
        /// </summary>
        /// <returns></returns>
        private async Task ReadFile()
        {
            string data = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(this.file))
                {
                    while (!streamReader.EndOfStream)
                    {
                        data = await streamReader.ReadLineAsync();
                        fileDataQueue.Enqueue(data);
                    }
                }
            }
            catch(FileNotFoundException )
            {
                Console.WriteLine($"Given file {file} not found");
                throw;
            }
            catch (FileLoadException)
            {
                Console.WriteLine($"Error is opening file {file} ");
                throw;
            }                        

        }
        
        /// <summary>
        /// Process Data from the input data
        /// </summary>
        /// <returns></returns>
       private async Task ProcessCreditCards()
       {
            await Task.Run(() => {
                string[] data = null;

                while (counter < MaxCunter)
                {
                    if (fileDataQueue.Count == 0)
                    {
                        Thread.Sleep(20);
                        counter++;
                    }

                    while (fileDataQueue.Count > 0)
                    {
                        counter = 0;
                        data = fileDataQueue.Dequeue().Split(' ');

                        if (data.Length <= 1)
                            continue;

                        switch (data[0])
                        {
                            case Operations.ADD:
                                {
                                    creditCardProcessAccessLayer.AddMoneyToCardHolderCard(creditCardHolderName: data[1], creditCardNumber: data[2], maxMoneyLimit: long.Parse(data[3].Substring(1)));
                                    break;
                                }
                            case Operations.CHARGE:
                                {
                                    creditCardProcessAccessLayer.ChargeCardHolder(creditCardHolderName: data[1], money: long.Parse(data[2].Substring(1)));
                                    break;
                                }
                            case Operations.CREDIT:
                                {
                                    creditCardProcessAccessLayer.Credit_A_CardHolder(creditCardHolderName: data[1], money: long.Parse(data[2].Substring(1)));
                                    break;
                                }
                        }
                    }
                }
            
            });
       }

        public void Execute()
        {
            try
            {
                Task[] task = new Task[2];
                task[0] = Task.Run(() => this.ReadFile());
                task[1] = Task.Run(() => this.ProcessCreditCards());
                Task.WaitAll(task);
                this.Report();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured : \nMessage: {ex.Message}\nInnerException:{ex.InnerException}\nStackTrace: {ex.StackTrace}");
            }

        }


        private void Report()
        {
            if (creditCardProcessAccessLayer.CardHolders.Count > 0)
            {
                var cardHolders = creditCardProcessAccessLayer.CardHolders;
                CreditCardHolderDetail temp = null;
                Console.WriteLine("```");
                foreach (string key in cardHolders.Keys)
                {
                    cardHolders.TryGetValue(key, out temp);
                    if (temp == null)
                        Console.WriteLine($"{key}: error");
                    else
                        Console.WriteLine($"{key}: ${temp.CurrentMoney}");
                }
                Console.WriteLine("```");
            }
        }


    }
}
