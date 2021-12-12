\connect AppMetrics
CREATE TABLE Weather
(
 Id serial PRIMARY KEY,
 WeatherType VARCHAR (100) NOT NULL
);
ALTER TABLE Weather OWNER TO appmetrics_admin;
Insert into Weather(WeatherType) values('Freezing');
Insert into Weather(WeatherType) values('Bracing');
Insert into Weather(WeatherType) values('Chilly');
Insert into Weather(WeatherType) values('Cool');
Insert into Weather(WeatherType) values('Mild');
Insert into Weather(WeatherType) values('Warm');
Insert into Weather(WeatherType) values('Balmy');
Insert into Weather(WeatherType) values('Hot');
Insert into Weather(WeatherType) values('Sweltering');
Insert into Weather(WeatherType) values('Scorching');
