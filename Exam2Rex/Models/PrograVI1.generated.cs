//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : PrograVI
	/// Data Source    : IN3114
	/// Server Version : 16.00.1135
	/// </summary>
	public partial class PrograVIDB : LinqToDB.Data.DataConnection
	{
		public ITable<Cantone>    Cantones    { get { return this.GetTable<Cantone>(); } }
		public ITable<Distrito>   Distritos   { get { return this.GetTable<Distrito>(); } }
		public ITable<Estudiante> Estudiantes { get { return this.GetTable<Estudiante>(); } }
		public ITable<Provincia>  Provincias  { get { return this.GetTable<Provincia>(); } }

		public PrograVIDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PrograVIDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PrograVIDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PrograVIDB(DataOptions<PrograVIDB> options)
			: base(options.Options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="cantones")]
	public partial class Cantone
	{
		[Column("id_canton"),     PrimaryKey, Identity] public int    IdCanton     { get; set; } // int
		[Column("id_provincia"),  NotNull             ] public int    IdProvincia  { get; set; } // int
		[Column("nombre_canton"), NotNull             ] public string NombreCanton { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK__distritos__id_ca__3C69FB99_BackReference (dbo.distritos)
		/// </summary>
		[Association(ThisKey="IdCanton", OtherKey="IdCanton", CanBeNull=true)]
		public IEnumerable<Distrito> Distritosidca3C69Fbs { get; set; }

		/// <summary>
		/// FK__cantones__id_pro__398D8EEE (dbo.provincias)
		/// </summary>
		[Association(ThisKey="IdProvincia", OtherKey="IdProvincia", CanBeNull=false)]
		public Provincia Idpro398D8EEE { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="distritos")]
	public partial class Distrito
	{
		[Column("id_distrito"),     PrimaryKey, Identity] public int    IdDistrito     { get; set; } // int
		[Column("id_canton"),       NotNull             ] public int    IdCanton       { get; set; } // int
		[Column("nombre_distrito"), NotNull             ] public string NombreDistrito { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK__estudiant__id_di__3F466844_BackReference (dbo.estudiantes)
		/// </summary>
		[Association(ThisKey="IdDistrito", OtherKey="IdDistrito", CanBeNull=true)]
		public IEnumerable<Estudiante> Estudiantiddi3F { get; set; }

		/// <summary>
		/// FK__distritos__id_ca__3C69FB99 (dbo.cantones)
		/// </summary>
		[Association(ThisKey="IdCanton", OtherKey="IdCanton", CanBeNull=false)]
		public Cantone Idca3C69FB { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="estudiantes")]
	public partial class Estudiante
	{
		[Column("id_estudiante"),         PrimaryKey,  Identity] public int      IdEstudiante         { get; set; } // int
		[Column("nombre"),                NotNull              ] public string   Nombre               { get; set; } // varchar(100)
		[Column("id_distrito"),           NotNull              ] public int      IdDistrito           { get; set; } // int
		[Column("prueba_parcial_1"),         Nullable          ] public decimal? PruebaParcial1       { get; set; } // decimal(5, 2)
		[Column("prueba_parcial_2"),         Nullable          ] public decimal? PruebaParcial2       { get; set; } // decimal(5, 2)
		[Column("asignacion"),               Nullable          ] public decimal? Asignacion           { get; set; } // decimal(5, 2)
		[Column("proyecto"),                 Nullable          ] public decimal? Proyecto             { get; set; } // decimal(5, 2)
		[Column("trabajo_investigacion"),    Nullable          ] public decimal? TrabajoInvestigacion { get; set; } // decimal(5, 2)

		#region Associations

		/// <summary>
		/// FK__estudiant__id_di__3F466844 (dbo.distritos)
		/// </summary>
		[Association(ThisKey="IdDistrito", OtherKey="IdDistrito", CanBeNull=false)]
		public Distrito Estudiantiddi3F { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="provincias")]
	public partial class Provincia
	{
		[Column("id_provincia"),     PrimaryKey, Identity] public int    IdProvincia     { get; set; } // int
		[Column("nombre_provincia"), NotNull             ] public string NombreProvincia { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK__cantones__id_pro__398D8EEE_BackReference (dbo.cantones)
		/// </summary>
		[Association(ThisKey="IdProvincia", OtherKey="IdProvincia", CanBeNull=true)]
		public IEnumerable<Cantone> Cantonesidpro398D8Eees { get; set; }

		#endregion
	}

	public static partial class PrograVIDBStoredProcedures
	{
		#region InsertarEstudiante

		public static int InsertarEstudiante(this PrograVIDB dataConnection, string @Nombre, int? @IdDistrito, decimal? @PruebaParcial1, decimal? @PruebaParcial2, decimal? @Asignacion, decimal? @Proyecto, decimal? @TrabajoInvestigacion)
		{
			var parameters = new []
			{
				new DataParameter("@Nombre",               @Nombre,               LinqToDB.DataType.NVarChar)
				{
					Size = 100
				},
				new DataParameter("@IdDistrito",           @IdDistrito,           LinqToDB.DataType.Int32),
				new DataParameter("@PruebaParcial1",       @PruebaParcial1,       LinqToDB.DataType.Decimal),
				new DataParameter("@PruebaParcial2",       @PruebaParcial2,       LinqToDB.DataType.Decimal),
				new DataParameter("@Asignacion",           @Asignacion,           LinqToDB.DataType.Decimal),
				new DataParameter("@Proyecto",             @Proyecto,             LinqToDB.DataType.Decimal),
				new DataParameter("@TrabajoInvestigacion", @TrabajoInvestigacion, LinqToDB.DataType.Decimal)
			};

			return dataConnection.ExecuteProc("[dbo].[InsertarEstudiante]", parameters);
		}

		#endregion

		#region ObtenerCantonesPorProvincia

		public static IEnumerable<ObtenerCantonesPorProvinciaResult> ObtenerCantonesPorProvincia(this PrograVIDB dataConnection, int? @IdProvincia)
		{
			var parameters = new []
			{
				new DataParameter("@IdProvincia", @IdProvincia, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<ObtenerCantonesPorProvinciaResult>("[dbo].[ObtenerCantonesPorProvincia]", parameters);
		}

		public partial class ObtenerCantonesPorProvinciaResult
		{
			public int    IdCanton     { get; set; }
			public string NombreCanton { get; set; }
		}

		#endregion

		#region ObtenerDistritosPorCanton

		public static IEnumerable<ObtenerDistritosPorCantonResult> ObtenerDistritosPorCanton(this PrograVIDB dataConnection, int? @IdCanton)
		{
			var parameters = new []
			{
				new DataParameter("@IdCanton", @IdCanton, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<ObtenerDistritosPorCantonResult>("[dbo].[ObtenerDistritosPorCanton]", parameters);
		}

		public partial class ObtenerDistritosPorCantonResult
		{
			public int    IdDistrito     { get; set; }
			public string NombreDistrito { get; set; }
		}

		#endregion

		#region ObtenerEstudiantesConNotas

		public static IEnumerable<ObtenerEstudiantesConNotasResult> ObtenerEstudiantesConNotas(this PrograVIDB dataConnection)
		{
			return dataConnection.QueryProc<ObtenerEstudiantesConNotasResult>("[dbo].[ObtenerEstudiantesConNotas]");
		}

		public partial class ObtenerEstudiantesConNotasResult
		{
			[Column("estudiante")] public string   Estudiante { get; set; }
			[Column("nota")      ] public decimal? Nota       { get; set; }
			[Column("distrito")  ] public string   Distrito   { get; set; }
			[Column("canton")    ] public string   Canton     { get; set; }
			[Column("provincia") ] public string   Provincia  { get; set; }
		}

		#endregion

		#region ObtenerProvincias

		public static IEnumerable<ObtenerProvinciasResult> ObtenerProvincias(this PrograVIDB dataConnection)
		{
			return dataConnection.QueryProc<ObtenerProvinciasResult>("[dbo].[ObtenerProvincias]");
		}

		public partial class ObtenerProvinciasResult
		{
			public int    IdProvincia     { get; set; }
			public string NombreProvincia { get; set; }
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Cantone Find(this ITable<Cantone> table, int IdCanton)
		{
			return table.FirstOrDefault(t =>
				t.IdCanton == IdCanton);
		}

		public static Distrito Find(this ITable<Distrito> table, int IdDistrito)
		{
			return table.FirstOrDefault(t =>
				t.IdDistrito == IdDistrito);
		}

		public static Estudiante Find(this ITable<Estudiante> table, int IdEstudiante)
		{
			return table.FirstOrDefault(t =>
				t.IdEstudiante == IdEstudiante);
		}

		public static Provincia Find(this ITable<Provincia> table, int IdProvincia)
		{
			return table.FirstOrDefault(t =>
				t.IdProvincia == IdProvincia);
		}
	}
}