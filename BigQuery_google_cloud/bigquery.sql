1. Ir a la Consola de GCP

https://console.cloud.google.com

2. Inciar sesión con su user y password

3. En el menú de la izquierda, desplazarse a la sección BigData y seleccionar BigQuery

4. Si no está habilitada la API, favor de habilitarla

5. Seleccionar el dataset bigquery-public-data:noaa_gsod

6. Seleccionar la tabla gsod2017

7. Copie y pegue la siguiente consulta

SELECT
  -- Create a timestamp from the date components.
  stn,
  TIMESTAMP(CONCAT(year,"-",mo,"-",da)) AS timestamp,
  -- Replace numerical null values with actual null
  AVG(IF (temp=9999.9,
      null,
      temp)) AS temperature,
  AVG(IF (wdsp="999.9",
      null,
      CAST(wdsp AS Float64))) AS wind_speed,
  AVG(IF (prcp=99.99,
      0,
      prcp)) AS precipitation
FROM
  `bigquery-public-data.noaa_gsod.gsod*`
WHERE
  CAST(YEAR AS INT64) > 2010
  AND CAST(MO AS INT64) = 6
  AND CAST(DA AS INT64) = 12
  AND (stn="725030" OR  -- La Guardia
    stn="744860")    -- JFK
GROUP BY
  stn,
  timestamp
ORDER BY
  timestamp DESC,
  stn ASC

8. Modifique la tabla especificando el año, por ejemplo gsod2019, y note como varía la cantodad de datos a procesar.

9. Modifique la consulta anterior, elimando los filtros de año, mes y dia.

10. Ejecute la consulta

11. Analice los resultados en Data Studio

12. Modifique la consulta eliminando el filtro de las estaciones

SELECT
  -- Create a timestamp from the date components.
  stn,
  TIMESTAMP(CONCAT(year,"-",mo,"-",da)) AS timestamp,
  -- Replace numerical null values with actual null
  AVG(IF (temp=9999.9,
      null,
      temp)) AS temperature,
  AVG(IF (wdsp="999.9",
      null,
      CAST(wdsp AS Float64))) AS wind_speed,
  AVG(IF (prcp=99.99,
      0,
      prcp)) AS precipitation
FROM
  `bigquery-public-data.noaa_gsod.gsod2014`
GROUP BY
  stn,
  timestamp
ORDER BY
  timestamp DESC,
  stn ASC

Note que el número de registros resultantes es mucho mayor que en el query anterior.

13. Genere algunas gráficas en Data Studio