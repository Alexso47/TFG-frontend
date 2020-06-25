using PlataformaWEB.Models;
using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlataformaWEB.Infrastructure
{
    public class API
    {
        public static class EconomicOperator
        {
            public static string UpdateEconomicOperator(string baseUri)
            {
                return $"{baseUri}/Update";
            }

            public static string CreateEconomicOperator(string baseUri)
            {
                return $"{baseUri}/Create";
            }

            public static string GetEOIDS(string baseUri)
            {
                return $"{baseUri}/EOIDS";
            }

            public static string GetEOInfo(string baseUri, string eoid)
            {
                return $"{baseUri}/GetEOInfo?" +
                    $"Id={HttpUtility.UrlEncode(eoid)}";
            }
        }

        public static class EmailReport
        {
            //Arrival Report To Email
            public static string CreateArrivalReportToEmail()
            {
                return $"https://prod-121.westeurope.logic.azure.com:443" +
                    $"/workflows/1361cda1ec504365b2b05ccdb48f4027/triggers" +
                    $"/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%" +
                    $"2Fmanual%2Frun&sv=1.0&sig=N-nDOY8FHlgkDlnoVhVx-KYYAsbvMyK" +
                    $"wW78KqzOOmAk";
            }
            public static string UpdateArrivalReportToEmail()
            {
                return $"https://prod-177.westeurope.logic.azure.com:443/" +
                    $"workflows/0bcd3c5d5e5247869054cd0989f45205/triggers/" +
                    $"manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%" +
                    $"2Fmanual%2Frun&sv=1.0&sig=OVDItTVDJ9knFNF2qXrAjC9" +
                    $"_3uZxgOlaJZF7XFkt0uk";
            }

            //Dispatch Report To Email
            //public static string CreateDispatchReportToEmail()
            //{
            //    return $"https://prod-160.westeurope.logic.azure.com:443/workflows/2f9058318abe4f96b21bcb5699c25be4/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=2fHyWSiiDCuKdIqkmB3SYU6YjkdTa9WprRAg9JObUQQ";
            //}
            public static string UpdateDispatchReportToEmail()
            {
                return $"https://prod-172.westeurope.logic.azure.com:443/" +
                    $"workflows/2aa2a5a9ae404db2a2a06ebcc57fd0b2/triggers/" +
                    $"manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%" +
                    $"2Fmanual%2Frun&sv=1.0&sig=0yO9P4X9WyittlZuIlDI2zpvXzbc" +
                    $"F8GcDHM4f2N24rI";
            }

            //Invoice Report To Email
            //public static string CreateInvoiceReportToEmail()
            //{
            //    return $"https://prod-182.westeurope.logic.azure.com:443/workflows/8f141c6ee7584e849f567f22b9402c18/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=k7zIvZNAFDa6L4-8bttSbuQShqajBIdNYJeIbE-9Gng";
            //}
            public static string UpdateInvoiceReportToEmail()
            {
                return $"https://prod-112.westeurope.logic.azure.com:443/" +
                    $"workflows/45694e1582c347cdb25b2b814b5d08c6/triggers/" +
                    $"manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%" +
                    $"2Fmanual%2Frun&sv=1.0&sig=5qBcga5iiac0J2Hat_vkymO9bRXk7" +
                    $"0eQoGZTmu058KM";
            }

            //Serial Report To Email
            //public static string CreateSerialReportToEmail()
            //{
            //    return $"https://prod-44.westeurope.logic.azure.com:443/workflows/6c7edacf20fc4409be2cfd70b03f869b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=mN5UB-23LP7tzjheZHOYHoavbTaNJVc5pL5j5N9SmrA";
            //}
            public static string UpdateSerialReportToEmail()
            {
                return $"https://prod-114.westeurope.logic.azure.com:443/" +
                    $"workflows/36a1ff4b31c74f5e9e4dae16708ac6da/triggers/" +
                    $"manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%" +
                    $"2Fmanual%2Frun&sv=1.0&sig=qnNQPZmGj9u0GyF1QQkS52zYXnr" +
                    $"7p8zUR_A9sxkzeS8";
            }
        }

        public static class Facility
        {
            public static string CreateFacility(string baseUri)
            {
                return $"{baseUri}/Create";
            }

            public static string GetFIDs(string baseUri)
            {
                return $"{baseUri}/FIDS";
            }

            public static string GetFIDsByEOID(string baseUri, string eoid)
            {
                return $"{baseUri}/FIDSByEOID?" +
                    $"EOID={HttpUtility.UrlEncode(eoid)}";
            }

            public static string GetFacilityInfo(string baseUri, string fid)
            {
                return $"{baseUri}/GetFacilityInfo?" +
                    $"Id={HttpUtility.UrlEncode(fid)}";
            }
        }

        public static class Machine
        {
            public static string UpdateMachine(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string CreateMachine(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetMIDs(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetMIDsByFID(string baseUri, string fid)
            {
                return $"{baseUri}/GetMIDsByFID?" +
                    $"fid={HttpUtility.UrlEncode(fid)}";
            }

            public static string GetMachineInfo(string baseUri, string mid)
            {
                return $"{baseUri}/GetMachineInfo?" +
                    $"mid={HttpUtility.UrlEncode(mid)}";
            }

            public static string GetProductsNameByMID(string baseUri, string mid)
            {
                return $"{baseUri}/GetProductsNameByMID?" +
                    $"mid={HttpUtility.UrlEncode(mid)}";
            }

            //public static string Summary(string baseUri, string code, int countryId, string enabled, int pageIndex, int pageSize, IEnumerable<Sort> sortInfo)
            //{
            //    string sortUrl = GetSortUrlQuery(sortInfo);
            //    string paginationUrl = GetPaginationUrlQuery(pageIndex, pageSize);
            //    return $"{baseUri}?" +
            //        $"&code={HttpUtility.UrlEncode(code)}" +
            //        $"&countryId={countryId}" +
            //        $"&isEnabled={enabled}" +
            //        $"{paginationUrl}{sortUrl}";
            //}
        }

        public static class Request
        {
            public static string CreateRequest(string baseUri)
            {
                return $"{baseUri}";
            }
        }

        public static class Arrival
        {
            public static string RegisterArrival(string baseUri)
            {
                return $"{baseUri}/Create";
            }

            public static string GetArrivals(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFilteredArrivals(string baseUri, ArrivalFilters filters)
            {
                var id = filters.Id != null ? filters.Id : 0;

                string from = filters.From.HasValue ? EscapeDataString(filters.From.Value.ToString("o")) : string.Empty;
                string to = filters.To.HasValue ? EscapeDataString(filters.To.Value.ToString("o")) : string.Empty;

                return $"{baseUri}/Summary?" +
                    $"CreationDateFrom={from}" +
                    $"&CreationDateTo={to}" +
                    $"&id={id}" +
                    $"&fid={HttpUtility.UrlEncode(filters.FID)}";
            }
        }

        public static class Serial
        {
            public static string GetFilteredSerials(string baseUri, SerialFilters filters)
            {
                var id = filters.Id != null ? filters.Id : 0;

                return $"{baseUri}/Summary?" +
                    $"id={id}" +
                    $"&serial={HttpUtility.UrlEncode(filters.Serial)}";
            }
        }

        public static class Currency
        {
            public static string GetCurrencies(string baseUri)
            {
                return $"{baseUri}";
            }
        }

        public static class Invoice
        {
            public static string RegisterInvoice(string baseUri)
            {
                return $"{baseUri}/Create";
            }

            public static string GetInvoices(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFilteredInvoices(string baseUri, InvoiceFilters filters)
            {
                var id = filters.Id != null ? filters.Id : 0;
                var price = filters.Price != null ? filters.Price : 0;

                string from = filters.From.HasValue  ? EscapeDataString(filters.From.Value.ToString("o")) : string.Empty;
                string to = filters.To.HasValue ? EscapeDataString(filters.To.Value.ToString("o")) : string.Empty;

                return $"{baseUri}/Summary?" +
                    $"CreationDateFrom={from}" +
                    $"&CreationDateTo={to}" +
                    $"&id={id}" +
                    $"&price={price}" +
                    $"&currency={HttpUtility.UrlEncode(filters.Currency)}" +
                    $"&buyereu={filters.BuyerEU}" +
                    $"&buyerid={HttpUtility.UrlEncode(filters.BuyerID)}";

            }

            public static string GetFilteredInvoicesLA(string baseUri, InvoiceFilters filters)
            {
                var id = filters.Id != null ? filters.Id : 0;
                var price = filters.Price != null ? filters.Price : 0;

                string from = filters.From.HasValue  ? filters.From.Value.Date.ToString("yyyy-MM-dd") : string.Empty;
                string to = filters.To.HasValue ? filters.To.Value.Date.ToString("yyyy-MM-dd") : string.Empty;

                return $"" +
                    $"CreationDateFrom_{from}" +
                    $"1sep1CreationDateTo_{to}" +
                    $"1sep1id_{id}" +
                    $"1sep1price_{price}" +
                    $"1sep1currency_{HttpUtility.UrlEncode(filters.Currency)}" +
                    $"1sep1buyereu_{filters.BuyerEU}" +
                    $"1sep1buyerid_{HttpUtility.UrlEncode(filters.BuyerID)}";

            }
        }
        public static class Dispatch
        {
            public static string RegisterDispatch(string baseUri)
            {
                return $"{baseUri}/Create";
            }

            public static string GetDispatches(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFilteredDispatches(string baseUri, DispatchFilters filters)
            {
                var id = filters.Id != null ? filters.Id : 0;

                string from = filters.From.HasValue ? EscapeDataString(filters.From.Value.ToString("o")) : string.Empty;
                string to = filters.To.HasValue ? EscapeDataString(filters.To.Value.ToString("o")) : string.Empty;

                return $"{baseUri}/Summary?" +
                    $"CreationDateFrom={from}" +
                    $"&CreationDateTo={to}" +
                    $"&id={id}" +
                    $"&fid={HttpUtility.UrlEncode(filters.FID)}" +
                    $"&destinationfid={HttpUtility.UrlEncode(filters.DestinationFID)}" +
                    $"&transportmode={HttpUtility.UrlEncode(filters.TransportMode)}" +
                    $"&vehicle={HttpUtility.UrlEncode(filters.Vehicle)}" +
                    $"&destinationeu={filters.DestinationEU}";
            }
        }

        // Uso general
        private static string GetPaginationUrlQuery(int pageIndex, int pageSize)
        {
            return $"&pageindex={pageIndex}&pagesize={pageSize}";
        }
        private static string GetSortUrlQuery(IEnumerable<Sort> sortInfo)
        {
            int i = 0;
            string sortSerialized = string.Empty;
            if (sortInfo != null)
            {
                foreach (Sort sort in sortInfo)
                {
                    sortSerialized = sortSerialized + $"&sortInfo[{i}].direction={sort.Direction}&sortInfo[{i}].columnName={sort.ColumnName}";
                    i++;
                }
            }
            return sortSerialized;
        }

        private static string EscapeDataString(string value)
        {
            if (value != null)
            {
                return Uri.EscapeDataString(value);
            }
            return string.Empty;
        }
    }
}
