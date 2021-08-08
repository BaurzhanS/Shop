using ClosedXML.Excel;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public class ExcelHepler<T>
    {
        public static byte[] ExportToExcel(IEnumerable<T> items)
        {
            if (items.Count() > 0)
            {
                var item = items.FirstOrDefault();
                string type = item.GetType().Name;
                if(type == "Order")
                {
                    var orders = items as IEnumerable<Order>;
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Orders");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "OrderId";
                        worksheet.Cell(currentRow, 2).Value = "OrderDate";
                        worksheet.Cell(currentRow, 3).Value = "DeliveryRegionId";
                        worksheet.Cell(currentRow, 4).Value = "OrderPrice";
                        foreach (var order in orders)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = order.OrderId;
                            worksheet.Cell(currentRow, 2).Value = order.OrderDate;
                            worksheet.Cell(currentRow, 3).Value = order.DeliveryRegionId;
                            worksheet.Cell(currentRow, 4).Value = order.OrderPrice;
                        }

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return content;
                        }
                    }
                }
                else if (type == "User")
                {
                    var users = items as IEnumerable<User>;
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Users");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "FirstName";
                        worksheet.Cell(currentRow, 2).Value = "LastName";
                        worksheet.Cell(currentRow, 3).Value = "RoleName";
                        worksheet.Cell(currentRow, 4).Value = "Password";
                        foreach (var user in users)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = user.FirstName;
                            worksheet.Cell(currentRow, 2).Value = user.LastName;
                            worksheet.Cell(currentRow, 3).Value = user.RoleName;
                            worksheet.Cell(currentRow, 4).Value = user.Password;
                        }

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return content;
                        }
                    }
                }
                else if (type == "Region")
                {
                    var regions = items as IEnumerable<Region>;
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Users");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "RegionId";
                        worksheet.Cell(currentRow, 2).Value = "RegionName";
                        worksheet.Cell(currentRow, 3).Value = "ParentId";
                        worksheet.Cell(currentRow, 3).Value = "ParentName";

                        foreach (var region in regions)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = region.RegionId;
                            worksheet.Cell(currentRow, 2).Value = region.RegionName;
                            worksheet.Cell(currentRow, 3).Value = region.ParentId;
                            worksheet.Cell(currentRow, 3).Value = region.ParentName;
                        }

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return content;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
