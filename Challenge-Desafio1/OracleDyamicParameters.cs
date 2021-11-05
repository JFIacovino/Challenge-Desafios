using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace WebAPI___Integracion
{
    public class OracleDyamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            OracleParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, size.Value, value, direction);
            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
            }

            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            var oracleParameter = new OracleParameter(name, oracleDbType, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }

        public int GetInt(string parameterName)
        {
            var parameter = oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)

                return Convert.ToInt32(parameter.Value.ToString());
                
            return -11111;
        }

        public String GetString(string parameterName)
        {
            var parameter = oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)

                return parameter.Value.ToString();

            return "";
        }

        public String GetClob(string parameterName)
        {
            var parameter = oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)

                return parameter.Value.ToString();

            return "";
        }

        public DataTable GetCursor(string parameterName)
        {

            DataTable table = new DataTable();
            var parameter = oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            

            return table;
            
            //  if (parameter != null)

                //return parameter;

            //return parameter.Value ;
        }


    }
}
