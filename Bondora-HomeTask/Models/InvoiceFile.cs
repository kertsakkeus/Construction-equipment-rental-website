﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class InvoiceFile
    {
        public static async Task<string> MakeInvoice(string name, string last_name, string country, string address, string zipcode, string city, string province, string phone, string email, string currentPath)
        {
            try
            {
                List<InvoiceItems> invoiceItems = new List<InvoiceItems>();

                invoiceItems = await ApiRequests.GetInvoiceInfo();

                string path = currentPath.Substring(0, currentPath.Length - 16) + "invoice.txt";

                if (invoiceItems != null)
                {
                    int totalPrice = 0;
                    int loyaltyPoints = 0;

                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("----------------------------INVOICE-------------------------------\n");

                            sw.WriteLine("Test OÜ");
                            sw.WriteLine("Paldiski maantee 203, 13517 Tallinn, Estonia");
                            sw.WriteLine("+372 5854 8945");
                            sw.WriteLine("test@test.com");

                            sw.WriteLine("\n----------------------------INVOICE TO----------------------------\n");

                            sw.WriteLine(name + " " + last_name);
                            sw.WriteLine(address + ", " + zipcode + " " + city + ", " + province + ", " + country);
                            sw.WriteLine(email);
                            sw.WriteLine(phone);

                            sw.WriteLine("\n----------------------------PRODUCTS------------------------------\n");

                            for (int i = 0; i < invoiceItems.Count; i++)
                            {
                                sw.WriteLine("Product: " + invoiceItems[i].Name);
                                sw.WriteLine("Price (1 Day): " + PriceCalculation.EquipmentPrice(invoiceItems[i].Type, 1) + "€");
                                sw.WriteLine("Type: " + invoiceItems[i].Type);
                                sw.WriteLine("Time: " + invoiceItems[i].Time);
                                sw.WriteLine("Total: " + invoiceItems[i].Price + "€" + "\n");

                                loyaltyPoints = loyaltyPoints + LoyaltyPointsManager.GetPoints(invoiceItems[i].Type);
                                totalPrice = totalPrice + Convert.ToInt32(invoiceItems[i].Price);
                            }

                            sw.WriteLine("----------------------------TOTAL---------------------------------\n");

                            sw.WriteLine("Total: " + totalPrice + "€");
                            sw.WriteLine("Loyalty points received: " + loyaltyPoints + "\n\n");
                            sw.WriteLine("Thank you for your purchase!");
                        }
                    }
                }
                return "Thank you for your purchase!";
            }
            catch
            {
                return "For some reason we can't make an invoice!";
            }
        }
    }
}