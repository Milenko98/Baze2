
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2021 00:19:03
-- Generated from EDMX file: C:\Users\Milenko\Desktop\BazeProj\Bolnica\Servis\Baza\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BolnicaDBB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BolnicaOsoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas] DROP CONSTRAINT [FK_BolnicaOsoba];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPregled_Pacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PacijentPregled] DROP CONSTRAINT [FK_PacijentPregled_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPregled_Pregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PacijentPregled] DROP CONSTRAINT [FK_PacijentPregled_Pregled];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentZdravstveniKarton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdravstveniKartons] DROP CONSTRAINT [FK_PacijentZdravstveniKarton];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregleda_Lekar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleda] DROP CONSTRAINT [FK_Pregleda_Lekar];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregleda_Pregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleda] DROP CONSTRAINT [FK_Pregleda_Pregled];
GO
IF OBJECT_ID(N'[dbo].[FK_ZdravstveniKartonDijagnoza_ZdravstveniKarton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdravstveniKartonDijagnoza] DROP CONSTRAINT [FK_ZdravstveniKartonDijagnoza_ZdravstveniKarton];
GO
IF OBJECT_ID(N'[dbo].[FK_ZdravstveniKartonDijagnoza_Dijagnoza]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdravstveniKartonDijagnoza] DROP CONSTRAINT [FK_ZdravstveniKartonDijagnoza_Dijagnoza];
GO
IF OBJECT_ID(N'[dbo].[FK_LekDijagnoza_Lek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LekDijagnoza] DROP CONSTRAINT [FK_LekDijagnoza_Lek];
GO
IF OBJECT_ID(N'[dbo].[FK_LekDijagnoza_Dijagnoza]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LekDijagnoza] DROP CONSTRAINT [FK_LekDijagnoza_Dijagnoza];
GO
IF OBJECT_ID(N'[dbo].[FK_DijagnozaLecenje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lecenjes] DROP CONSTRAINT [FK_DijagnozaLecenje];
GO
IF OBJECT_ID(N'[dbo].[FK_ZdravstveniKartonTerapija_ZdravstveniKarton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdravstveniKartonTerapija] DROP CONSTRAINT [FK_ZdravstveniKartonTerapija_ZdravstveniKarton];
GO
IF OBJECT_ID(N'[dbo].[FK_ZdravstveniKartonTerapija_Terapija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZdravstveniKartonTerapija] DROP CONSTRAINT [FK_ZdravstveniKartonTerapija_Terapija];
GO
IF OBJECT_ID(N'[dbo].[FK_TerapijaLecenje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lecenjes] DROP CONSTRAINT [FK_TerapijaLecenje];
GO
IF OBJECT_ID(N'[dbo].[FK_Izdaje_Uspostavlja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdaje] DROP CONSTRAINT [FK_Izdaje_Uspostavlja];
GO
IF OBJECT_ID(N'[dbo].[FK_Izdaje_Recept]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdaje] DROP CONSTRAINT [FK_Izdaje_Recept];
GO
IF OBJECT_ID(N'[dbo].[FK_PregledUspostavlja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uspostavljas] DROP CONSTRAINT [FK_PregledUspostavlja];
GO
IF OBJECT_ID(N'[dbo].[FK_UspostavljaDijagnoza]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uspostavljas] DROP CONSTRAINT [FK_UspostavljaDijagnoza];
GO
IF OBJECT_ID(N'[dbo].[FK_BolnicaMesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bolnicas] DROP CONSTRAINT [FK_BolnicaMesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pacijent_inherits_Osoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas_Pacijent] DROP CONSTRAINT [FK_Pacijent_inherits_Osoba];
GO
IF OBJECT_ID(N'[dbo].[FK_Radnik_inherits_Osoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas_Radnik] DROP CONSTRAINT [FK_Radnik_inherits_Osoba];
GO
IF OBJECT_ID(N'[dbo].[FK_Lekar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas_Lekar] DROP CONSTRAINT [FK_Lekar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Recepcioner_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas_Recepcioner] DROP CONSTRAINT [FK_Recepcioner_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Obezbedjenje_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobas_Obezbedjenje] DROP CONSTRAINT [FK_Obezbedjenje_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bolnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bolnicas];
GO
IF OBJECT_ID(N'[dbo].[Mestoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mestoes];
GO
IF OBJECT_ID(N'[dbo].[Osobas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas];
GO
IF OBJECT_ID(N'[dbo].[ZdravstveniKartons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZdravstveniKartons];
GO
IF OBJECT_ID(N'[dbo].[Dijagnozas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dijagnozas];
GO
IF OBJECT_ID(N'[dbo].[Leks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leks];
GO
IF OBJECT_ID(N'[dbo].[Terapijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terapijas];
GO
IF OBJECT_ID(N'[dbo].[Lecenjes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lecenjes];
GO
IF OBJECT_ID(N'[dbo].[Pregleds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregleds];
GO
IF OBJECT_ID(N'[dbo].[Uspostavljas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uspostavljas];
GO
IF OBJECT_ID(N'[dbo].[Recepts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recepts];
GO
IF OBJECT_ID(N'[dbo].[Osobas_Pacijent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[Osobas_Radnik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas_Radnik];
GO
IF OBJECT_ID(N'[dbo].[Osobas_Lekar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas_Lekar];
GO
IF OBJECT_ID(N'[dbo].[Osobas_Recepcioner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas_Recepcioner];
GO
IF OBJECT_ID(N'[dbo].[Osobas_Obezbedjenje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobas_Obezbedjenje];
GO
IF OBJECT_ID(N'[dbo].[PacijentPregled]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PacijentPregled];
GO
IF OBJECT_ID(N'[dbo].[Pregleda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregleda];
GO
IF OBJECT_ID(N'[dbo].[ZdravstveniKartonDijagnoza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZdravstveniKartonDijagnoza];
GO
IF OBJECT_ID(N'[dbo].[LekDijagnoza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LekDijagnoza];
GO
IF OBJECT_ID(N'[dbo].[ZdravstveniKartonTerapija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZdravstveniKartonTerapija];
GO
IF OBJECT_ID(N'[dbo].[Izdaje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izdaje];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bolnicas'
CREATE TABLE [dbo].[Bolnicas] (
    [Oznaka_B] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [MestoP_Broj] int  NOT NULL
);
GO

-- Creating table 'Mestoes'
CREATE TABLE [dbo].[Mestoes] (
    [P_Broj] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Osobas'
CREATE TABLE [dbo].[Osobas] (
    [Jmbg] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [BolnicaOznaka_B] int  NOT NULL,
    [MestoP_Broj] int  NOT NULL,
    [Radni_staz] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ZdravstveniKartons'
CREATE TABLE [dbo].[ZdravstveniKartons] (
    [Broj_K] int IDENTITY(1,1) NOT NULL,
    [Rok_vazenja] nvarchar(max)  NOT NULL,
    [Ime_pacijenta] nvarchar(max)  NOT NULL,
    [Prezime_pacijenta] nvarchar(max)  NOT NULL,
    [Pacijent_Jmbg] int  NOT NULL
);
GO

-- Creating table 'Dijagnozas'
CREATE TABLE [dbo].[Dijagnozas] (
    [Oznaka_D] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [UspostavljaPregledBroj_P] int  NOT NULL
);
GO

-- Creating table 'Leks'
CREATE TABLE [dbo].[Leks] (
    [Id_Leka] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Kolicina] int  NOT NULL
);
GO

-- Creating table 'Terapijas'
CREATE TABLE [dbo].[Terapijas] (
    [Broj_T] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Lecenjes'
CREATE TABLE [dbo].[Lecenjes] (
    [TerapijaBroj_T] int  NOT NULL,
    [DijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Pregleds'
CREATE TABLE [dbo].[Pregleds] (
    [Broj_P] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Ime_pacijenta] nvarchar(max)  NOT NULL,
    [Prezime_pacijenta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Uspostavljas'
CREATE TABLE [dbo].[Uspostavljas] (
    [PregledBroj_P] int  NOT NULL,
    [LecenjeId_Lecenja] int  NOT NULL,
    [DijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Recepts'
CREATE TABLE [dbo].[Recepts] (
    [Oznaka_R] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Osobas_Pacijent'
CREATE TABLE [dbo].[Osobas_Pacijent] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Osobas_Radnik'
CREATE TABLE [dbo].[Osobas_Radnik] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Osobas_Lekar'
CREATE TABLE [dbo].[Osobas_Lekar] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Osobas_Recepcioner'
CREATE TABLE [dbo].[Osobas_Recepcioner] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Osobas_Obezbedjenje'
CREATE TABLE [dbo].[Osobas_Obezbedjenje] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'PacijentPregled'
CREATE TABLE [dbo].[PacijentPregled] (
    [Pacijents_Jmbg] int  NOT NULL,
    [Pregleds_Broj_P] int  NOT NULL
);
GO

-- Creating table 'Pregleda'
CREATE TABLE [dbo].[Pregleda] (
    [Lekars_Jmbg] int  NOT NULL,
    [Pregleds_Broj_P] int  NOT NULL
);
GO

-- Creating table 'ZdravstveniKartonDijagnoza'
CREATE TABLE [dbo].[ZdravstveniKartonDijagnoza] (
    [ZdravstveniKartons_Broj_K] int  NOT NULL,
    [Dijagnozas_Oznaka_D] int  NOT NULL
);
GO

-- Creating table 'LekDijagnoza'
CREATE TABLE [dbo].[LekDijagnoza] (
    [Leks_Id_Leka] int  NOT NULL,
    [Dijagnozas_Oznaka_D] int  NOT NULL
);
GO

-- Creating table 'ZdravstveniKartonTerapija'
CREATE TABLE [dbo].[ZdravstveniKartonTerapija] (
    [ZdravstveniKartons_Broj_K] int  NOT NULL,
    [Terapijas_Broj_T] int  NOT NULL
);
GO

-- Creating table 'Izdaje'
CREATE TABLE [dbo].[Izdaje] (
    [Uspostavljas_PregledBroj_P] int  NOT NULL,
    [Uspostavljas_DijagnozaOznaka_D] int  NOT NULL,
    [Recepts_Oznaka_R] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Oznaka_B] in table 'Bolnicas'
ALTER TABLE [dbo].[Bolnicas]
ADD CONSTRAINT [PK_Bolnicas]
    PRIMARY KEY CLUSTERED ([Oznaka_B] ASC);
GO

-- Creating primary key on [P_Broj] in table 'Mestoes'
ALTER TABLE [dbo].[Mestoes]
ADD CONSTRAINT [PK_Mestoes]
    PRIMARY KEY CLUSTERED ([P_Broj] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas'
ALTER TABLE [dbo].[Osobas]
ADD CONSTRAINT [PK_Osobas]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Broj_K] in table 'ZdravstveniKartons'
ALTER TABLE [dbo].[ZdravstveniKartons]
ADD CONSTRAINT [PK_ZdravstveniKartons]
    PRIMARY KEY CLUSTERED ([Broj_K] ASC);
GO

-- Creating primary key on [Oznaka_D] in table 'Dijagnozas'
ALTER TABLE [dbo].[Dijagnozas]
ADD CONSTRAINT [PK_Dijagnozas]
    PRIMARY KEY CLUSTERED ([Oznaka_D] ASC);
GO

-- Creating primary key on [Id_Leka] in table 'Leks'
ALTER TABLE [dbo].[Leks]
ADD CONSTRAINT [PK_Leks]
    PRIMARY KEY CLUSTERED ([Id_Leka] ASC);
GO

-- Creating primary key on [Broj_T] in table 'Terapijas'
ALTER TABLE [dbo].[Terapijas]
ADD CONSTRAINT [PK_Terapijas]
    PRIMARY KEY CLUSTERED ([Broj_T] ASC);
GO

-- Creating primary key on [TerapijaBroj_T], [DijagnozaOznaka_D] in table 'Lecenjes'
ALTER TABLE [dbo].[Lecenjes]
ADD CONSTRAINT [PK_Lecenjes]
    PRIMARY KEY CLUSTERED ([TerapijaBroj_T], [DijagnozaOznaka_D] ASC);
GO

-- Creating primary key on [Broj_P] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [PK_Pregleds]
    PRIMARY KEY CLUSTERED ([Broj_P] ASC);
GO

-- Creating primary key on [PregledBroj_P], [DijagnozaOznaka_D] in table 'Uspostavljas'
ALTER TABLE [dbo].[Uspostavljas]
ADD CONSTRAINT [PK_Uspostavljas]
    PRIMARY KEY CLUSTERED ([PregledBroj_P], [DijagnozaOznaka_D] ASC);
GO

-- Creating primary key on [Oznaka_R] in table 'Recepts'
ALTER TABLE [dbo].[Recepts]
ADD CONSTRAINT [PK_Recepts]
    PRIMARY KEY CLUSTERED ([Oznaka_R] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas_Pacijent'
ALTER TABLE [dbo].[Osobas_Pacijent]
ADD CONSTRAINT [PK_Osobas_Pacijent]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas_Radnik'
ALTER TABLE [dbo].[Osobas_Radnik]
ADD CONSTRAINT [PK_Osobas_Radnik]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas_Lekar'
ALTER TABLE [dbo].[Osobas_Lekar]
ADD CONSTRAINT [PK_Osobas_Lekar]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas_Recepcioner'
ALTER TABLE [dbo].[Osobas_Recepcioner]
ADD CONSTRAINT [PK_Osobas_Recepcioner]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Osobas_Obezbedjenje'
ALTER TABLE [dbo].[Osobas_Obezbedjenje]
ADD CONSTRAINT [PK_Osobas_Obezbedjenje]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Pacijents_Jmbg], [Pregleds_Broj_P] in table 'PacijentPregled'
ALTER TABLE [dbo].[PacijentPregled]
ADD CONSTRAINT [PK_PacijentPregled]
    PRIMARY KEY CLUSTERED ([Pacijents_Jmbg], [Pregleds_Broj_P] ASC);
GO

-- Creating primary key on [Lekars_Jmbg], [Pregleds_Broj_P] in table 'Pregleda'
ALTER TABLE [dbo].[Pregleda]
ADD CONSTRAINT [PK_Pregleda]
    PRIMARY KEY CLUSTERED ([Lekars_Jmbg], [Pregleds_Broj_P] ASC);
GO

-- Creating primary key on [ZdravstveniKartons_Broj_K], [Dijagnozas_Oznaka_D] in table 'ZdravstveniKartonDijagnoza'
ALTER TABLE [dbo].[ZdravstveniKartonDijagnoza]
ADD CONSTRAINT [PK_ZdravstveniKartonDijagnoza]
    PRIMARY KEY CLUSTERED ([ZdravstveniKartons_Broj_K], [Dijagnozas_Oznaka_D] ASC);
GO

-- Creating primary key on [Leks_Id_Leka], [Dijagnozas_Oznaka_D] in table 'LekDijagnoza'
ALTER TABLE [dbo].[LekDijagnoza]
ADD CONSTRAINT [PK_LekDijagnoza]
    PRIMARY KEY CLUSTERED ([Leks_Id_Leka], [Dijagnozas_Oznaka_D] ASC);
GO

-- Creating primary key on [ZdravstveniKartons_Broj_K], [Terapijas_Broj_T] in table 'ZdravstveniKartonTerapija'
ALTER TABLE [dbo].[ZdravstveniKartonTerapija]
ADD CONSTRAINT [PK_ZdravstveniKartonTerapija]
    PRIMARY KEY CLUSTERED ([ZdravstveniKartons_Broj_K], [Terapijas_Broj_T] ASC);
GO

-- Creating primary key on [Uspostavljas_PregledBroj_P], [Uspostavljas_DijagnozaOznaka_D], [Recepts_Oznaka_R] in table 'Izdaje'
ALTER TABLE [dbo].[Izdaje]
ADD CONSTRAINT [PK_Izdaje]
    PRIMARY KEY CLUSTERED ([Uspostavljas_PregledBroj_P], [Uspostavljas_DijagnozaOznaka_D], [Recepts_Oznaka_R] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BolnicaOznaka_B] in table 'Osobas'
ALTER TABLE [dbo].[Osobas]
ADD CONSTRAINT [FK_BolnicaOsoba]
    FOREIGN KEY ([BolnicaOznaka_B])
    REFERENCES [dbo].[Bolnicas]
        ([Oznaka_B])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BolnicaOsoba'
CREATE INDEX [IX_FK_BolnicaOsoba]
ON [dbo].[Osobas]
    ([BolnicaOznaka_B]);
GO

-- Creating foreign key on [Pacijents_Jmbg] in table 'PacijentPregled'
ALTER TABLE [dbo].[PacijentPregled]
ADD CONSTRAINT [FK_PacijentPregled_Pacijent]
    FOREIGN KEY ([Pacijents_Jmbg])
    REFERENCES [dbo].[Osobas_Pacijent]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pregleds_Broj_P] in table 'PacijentPregled'
ALTER TABLE [dbo].[PacijentPregled]
ADD CONSTRAINT [FK_PacijentPregled_Pregled]
    FOREIGN KEY ([Pregleds_Broj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentPregled_Pregled'
CREATE INDEX [IX_FK_PacijentPregled_Pregled]
ON [dbo].[PacijentPregled]
    ([Pregleds_Broj_P]);
GO

-- Creating foreign key on [Pacijent_Jmbg] in table 'ZdravstveniKartons'
ALTER TABLE [dbo].[ZdravstveniKartons]
ADD CONSTRAINT [FK_PacijentZdravstveniKarton]
    FOREIGN KEY ([Pacijent_Jmbg])
    REFERENCES [dbo].[Osobas_Pacijent]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentZdravstveniKarton'
CREATE INDEX [IX_FK_PacijentZdravstveniKarton]
ON [dbo].[ZdravstveniKartons]
    ([Pacijent_Jmbg]);
GO

-- Creating foreign key on [Lekars_Jmbg] in table 'Pregleda'
ALTER TABLE [dbo].[Pregleda]
ADD CONSTRAINT [FK_Pregleda_Lekar]
    FOREIGN KEY ([Lekars_Jmbg])
    REFERENCES [dbo].[Osobas_Lekar]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pregleds_Broj_P] in table 'Pregleda'
ALTER TABLE [dbo].[Pregleda]
ADD CONSTRAINT [FK_Pregleda_Pregled]
    FOREIGN KEY ([Pregleds_Broj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregleda_Pregled'
CREATE INDEX [IX_FK_Pregleda_Pregled]
ON [dbo].[Pregleda]
    ([Pregleds_Broj_P]);
GO

-- Creating foreign key on [ZdravstveniKartons_Broj_K] in table 'ZdravstveniKartonDijagnoza'
ALTER TABLE [dbo].[ZdravstveniKartonDijagnoza]
ADD CONSTRAINT [FK_ZdravstveniKartonDijagnoza_ZdravstveniKarton]
    FOREIGN KEY ([ZdravstveniKartons_Broj_K])
    REFERENCES [dbo].[ZdravstveniKartons]
        ([Broj_K])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dijagnozas_Oznaka_D] in table 'ZdravstveniKartonDijagnoza'
ALTER TABLE [dbo].[ZdravstveniKartonDijagnoza]
ADD CONSTRAINT [FK_ZdravstveniKartonDijagnoza_Dijagnoza]
    FOREIGN KEY ([Dijagnozas_Oznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZdravstveniKartonDijagnoza_Dijagnoza'
CREATE INDEX [IX_FK_ZdravstveniKartonDijagnoza_Dijagnoza]
ON [dbo].[ZdravstveniKartonDijagnoza]
    ([Dijagnozas_Oznaka_D]);
GO

-- Creating foreign key on [Leks_Id_Leka] in table 'LekDijagnoza'
ALTER TABLE [dbo].[LekDijagnoza]
ADD CONSTRAINT [FK_LekDijagnoza_Lek]
    FOREIGN KEY ([Leks_Id_Leka])
    REFERENCES [dbo].[Leks]
        ([Id_Leka])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dijagnozas_Oznaka_D] in table 'LekDijagnoza'
ALTER TABLE [dbo].[LekDijagnoza]
ADD CONSTRAINT [FK_LekDijagnoza_Dijagnoza]
    FOREIGN KEY ([Dijagnozas_Oznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LekDijagnoza_Dijagnoza'
CREATE INDEX [IX_FK_LekDijagnoza_Dijagnoza]
ON [dbo].[LekDijagnoza]
    ([Dijagnozas_Oznaka_D]);
GO

-- Creating foreign key on [DijagnozaOznaka_D] in table 'Lecenjes'
ALTER TABLE [dbo].[Lecenjes]
ADD CONSTRAINT [FK_DijagnozaLecenje]
    FOREIGN KEY ([DijagnozaOznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DijagnozaLecenje'
CREATE INDEX [IX_FK_DijagnozaLecenje]
ON [dbo].[Lecenjes]
    ([DijagnozaOznaka_D]);
GO

-- Creating foreign key on [ZdravstveniKartons_Broj_K] in table 'ZdravstveniKartonTerapija'
ALTER TABLE [dbo].[ZdravstveniKartonTerapija]
ADD CONSTRAINT [FK_ZdravstveniKartonTerapija_ZdravstveniKarton]
    FOREIGN KEY ([ZdravstveniKartons_Broj_K])
    REFERENCES [dbo].[ZdravstveniKartons]
        ([Broj_K])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Terapijas_Broj_T] in table 'ZdravstveniKartonTerapija'
ALTER TABLE [dbo].[ZdravstveniKartonTerapija]
ADD CONSTRAINT [FK_ZdravstveniKartonTerapija_Terapija]
    FOREIGN KEY ([Terapijas_Broj_T])
    REFERENCES [dbo].[Terapijas]
        ([Broj_T])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZdravstveniKartonTerapija_Terapija'
CREATE INDEX [IX_FK_ZdravstveniKartonTerapija_Terapija]
ON [dbo].[ZdravstveniKartonTerapija]
    ([Terapijas_Broj_T]);
GO

-- Creating foreign key on [TerapijaBroj_T] in table 'Lecenjes'
ALTER TABLE [dbo].[Lecenjes]
ADD CONSTRAINT [FK_TerapijaLecenje]
    FOREIGN KEY ([TerapijaBroj_T])
    REFERENCES [dbo].[Terapijas]
        ([Broj_T])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Uspostavljas_PregledBroj_P], [Uspostavljas_DijagnozaOznaka_D] in table 'Izdaje'
ALTER TABLE [dbo].[Izdaje]
ADD CONSTRAINT [FK_Izdaje_Uspostavlja]
    FOREIGN KEY ([Uspostavljas_PregledBroj_P], [Uspostavljas_DijagnozaOznaka_D])
    REFERENCES [dbo].[Uspostavljas]
        ([PregledBroj_P], [DijagnozaOznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Recepts_Oznaka_R] in table 'Izdaje'
ALTER TABLE [dbo].[Izdaje]
ADD CONSTRAINT [FK_Izdaje_Recept]
    FOREIGN KEY ([Recepts_Oznaka_R])
    REFERENCES [dbo].[Recepts]
        ([Oznaka_R])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Izdaje_Recept'
CREATE INDEX [IX_FK_Izdaje_Recept]
ON [dbo].[Izdaje]
    ([Recepts_Oznaka_R]);
GO

-- Creating foreign key on [PregledBroj_P] in table 'Uspostavljas'
ALTER TABLE [dbo].[Uspostavljas]
ADD CONSTRAINT [FK_PregledUspostavlja]
    FOREIGN KEY ([PregledBroj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DijagnozaOznaka_D] in table 'Uspostavljas'
ALTER TABLE [dbo].[Uspostavljas]
ADD CONSTRAINT [FK_UspostavljaDijagnoza]
    FOREIGN KEY ([DijagnozaOznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UspostavljaDijagnoza'
CREATE INDEX [IX_FK_UspostavljaDijagnoza]
ON [dbo].[Uspostavljas]
    ([DijagnozaOznaka_D]);
GO

-- Creating foreign key on [MestoP_Broj] in table 'Bolnicas'
ALTER TABLE [dbo].[Bolnicas]
ADD CONSTRAINT [FK_BolnicaMesto]
    FOREIGN KEY ([MestoP_Broj])
    REFERENCES [dbo].[Mestoes]
        ([P_Broj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BolnicaMesto'
CREATE INDEX [IX_FK_BolnicaMesto]
ON [dbo].[Bolnicas]
    ([MestoP_Broj]);
GO

-- Creating foreign key on [Jmbg] in table 'Osobas_Pacijent'
ALTER TABLE [dbo].[Osobas_Pacijent]
ADD CONSTRAINT [FK_Pacijent_inherits_Osoba]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Osobas]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Osobas_Radnik'
ALTER TABLE [dbo].[Osobas_Radnik]
ADD CONSTRAINT [FK_Radnik_inherits_Osoba]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Osobas]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Osobas_Lekar'
ALTER TABLE [dbo].[Osobas_Lekar]
ADD CONSTRAINT [FK_Lekar_inherits_Radnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Osobas_Radnik]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Osobas_Recepcioner'
ALTER TABLE [dbo].[Osobas_Recepcioner]
ADD CONSTRAINT [FK_Recepcioner_inherits_Radnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Osobas_Radnik]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Osobas_Obezbedjenje'
ALTER TABLE [dbo].[Osobas_Obezbedjenje]
ADD CONSTRAINT [FK_Obezbedjenje_inherits_Radnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Osobas_Radnik]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------