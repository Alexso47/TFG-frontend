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
