
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2021 22:58:11
-- Generated from EDMX file: C:\Users\Milenko\Desktop\BazeProj\Bolnica\Servis\Baza\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BolnicaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [LecenjeTerapijaBroj_T] int  NOT NULL,
    [LecenjeDijagnozaOznaka_D] int  NOT NULL,
    [DijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Recepts'
CREATE TABLE [dbo].[Recepts] (
    [Oznaka_R] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SeLecis'
CREATE TABLE [dbo].[SeLecis] (
    [LekId_Leka] int  NOT NULL,
    [DijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Sadrzis'
CREATE TABLE [dbo].[Sadrzis] (
    [ZdravstveniKartonBroj_K] int  NOT NULL,
    [DijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Posedujes'
CREATE TABLE [dbo].[Posedujes] (
    [ZdravstveniKartonBroj_K] int  NOT NULL,
    [TerapijaBroj_T] int  NOT NULL
);
GO

-- Creating table 'Izdajes'
CREATE TABLE [dbo].[Izdajes] (
    [ReceptOznaka_R] int  NOT NULL,
    [UspostavljaPregledBroj_P] int  NOT NULL,
    [UspostavljaDijagnozaOznaka_D] int  NOT NULL
);
GO

-- Creating table 'Dolazis'
CREATE TABLE [dbo].[Dolazis] (
    [PacijentJmbg] int  NOT NULL,
    [PregledBroj_P] int  NOT NULL
);
GO

-- Creating table 'Pregledas'
CREATE TABLE [dbo].[Pregledas] (
    [LekarJmbg] int  NOT NULL,
    [PregledBroj_P] int  NOT NULL
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

-- Creating primary key on [LekId_Leka], [DijagnozaOznaka_D] in table 'SeLecis'
ALTER TABLE [dbo].[SeLecis]
ADD CONSTRAINT [PK_SeLecis]
    PRIMARY KEY CLUSTERED ([LekId_Leka], [DijagnozaOznaka_D] ASC);
GO

-- Creating primary key on [ZdravstveniKartonBroj_K], [DijagnozaOznaka_D] in table 'Sadrzis'
ALTER TABLE [dbo].[Sadrzis]
ADD CONSTRAINT [PK_Sadrzis]
    PRIMARY KEY CLUSTERED ([ZdravstveniKartonBroj_K], [DijagnozaOznaka_D] ASC);
GO

-- Creating primary key on [ZdravstveniKartonBroj_K], [TerapijaBroj_T] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [PK_Posedujes]
    PRIMARY KEY CLUSTERED ([ZdravstveniKartonBroj_K], [TerapijaBroj_T] ASC);
GO

-- Creating primary key on [ReceptOznaka_R], [UspostavljaPregledBroj_P], [UspostavljaDijagnozaOznaka_D] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [PK_Izdajes]
    PRIMARY KEY CLUSTERED ([ReceptOznaka_R], [UspostavljaPregledBroj_P], [UspostavljaDijagnozaOznaka_D] ASC);
GO

-- Creating primary key on [PacijentJmbg], [PregledBroj_P] in table 'Dolazis'
ALTER TABLE [dbo].[Dolazis]
ADD CONSTRAINT [PK_Dolazis]
    PRIMARY KEY CLUSTERED ([PacijentJmbg], [PregledBroj_P] ASC);
GO

-- Creating primary key on [LekarJmbg], [PregledBroj_P] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [PK_Pregledas]
    PRIMARY KEY CLUSTERED ([LekarJmbg], [PregledBroj_P] ASC);
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

-- Creating foreign key on [LekId_Leka] in table 'SeLecis'
ALTER TABLE [dbo].[SeLecis]
ADD CONSTRAINT [FK_LekSeLeci]
    FOREIGN KEY ([LekId_Leka])
    REFERENCES [dbo].[Leks]
        ([Id_Leka])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TerapijaBroj_T] in table 'Lecenjes'
ALTER TABLE [dbo].[Lecenjes]
ADD CONSTRAINT [FK_TerapijaLecenje]
    FOREIGN KEY ([TerapijaBroj_T])
    REFERENCES [dbo].[Terapijas]
        ([Broj_T])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PregledBroj_P] in table 'Uspostavljas'
ALTER TABLE [dbo].[Uspostavljas]
ADD CONSTRAINT [FK_PregledUspostavlja]
    FOREIGN KEY ([PregledBroj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ZdravstveniKartonBroj_K] in table 'Sadrzis'
ALTER TABLE [dbo].[Sadrzis]
ADD CONSTRAINT [FK_ZdravstveniKartonSadrzi]
    FOREIGN KEY ([ZdravstveniKartonBroj_K])
    REFERENCES [dbo].[ZdravstveniKartons]
        ([Broj_K])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ZdravstveniKartonBroj_K] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_ZdravstveniKartonPoseduje]
    FOREIGN KEY ([ZdravstveniKartonBroj_K])
    REFERENCES [dbo].[ZdravstveniKartons]
        ([Broj_K])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LecenjeTerapijaBroj_T], [LecenjeDijagnozaOznaka_D] in table 'Uspostavljas'
ALTER TABLE [dbo].[Uspostavljas]
ADD CONSTRAINT [FK_UspostavljaLecenje]
    FOREIGN KEY ([LecenjeTerapijaBroj_T], [LecenjeDijagnozaOznaka_D])
    REFERENCES [dbo].[Lecenjes]
        ([TerapijaBroj_T], [DijagnozaOznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UspostavljaLecenje'
CREATE INDEX [IX_FK_UspostavljaLecenje]
ON [dbo].[Uspostavljas]
    ([LecenjeTerapijaBroj_T], [LecenjeDijagnozaOznaka_D]);
GO

-- Creating foreign key on [DijagnozaOznaka_D] in table 'SeLecis'
ALTER TABLE [dbo].[SeLecis]
ADD CONSTRAINT [FK_SeLeciDijagnoza]
    FOREIGN KEY ([DijagnozaOznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeLeciDijagnoza'
CREATE INDEX [IX_FK_SeLeciDijagnoza]
ON [dbo].[SeLecis]
    ([DijagnozaOznaka_D]);
GO

-- Creating foreign key on [DijagnozaOznaka_D] in table 'Sadrzis'
ALTER TABLE [dbo].[Sadrzis]
ADD CONSTRAINT [FK_SadrziDijagnoza]
    FOREIGN KEY ([DijagnozaOznaka_D])
    REFERENCES [dbo].[Dijagnozas]
        ([Oznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SadrziDijagnoza'
CREATE INDEX [IX_FK_SadrziDijagnoza]
ON [dbo].[Sadrzis]
    ([DijagnozaOznaka_D]);
GO

-- Creating foreign key on [TerapijaBroj_T] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_PosedujeTerapija]
    FOREIGN KEY ([TerapijaBroj_T])
    REFERENCES [dbo].[Terapijas]
        ([Broj_T])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PosedujeTerapija'
CREATE INDEX [IX_FK_PosedujeTerapija]
ON [dbo].[Posedujes]
    ([TerapijaBroj_T]);
GO

-- Creating foreign key on [LekarJmbg] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [FK_LekarPregleda]
    FOREIGN KEY ([LekarJmbg])
    REFERENCES [dbo].[Osobas_Lekar]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PregledBroj_P] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [FK_PregledaPregled]
    FOREIGN KEY ([PregledBroj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PregledaPregled'
CREATE INDEX [IX_FK_PregledaPregled]
ON [dbo].[Pregledas]
    ([PregledBroj_P]);
GO

-- Creating foreign key on [ReceptOznaka_R] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_IzdajeRecept]
    FOREIGN KEY ([ReceptOznaka_R])
    REFERENCES [dbo].[Recepts]
        ([Oznaka_R])
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

-- Creating foreign key on [PacijentJmbg] in table 'Dolazis'
ALTER TABLE [dbo].[Dolazis]
ADD CONSTRAINT [FK_PacijentDolazi]
    FOREIGN KEY ([PacijentJmbg])
    REFERENCES [dbo].[Osobas_Pacijent]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PregledBroj_P] in table 'Dolazis'
ALTER TABLE [dbo].[Dolazis]
ADD CONSTRAINT [FK_DolaziPregled]
    FOREIGN KEY ([PregledBroj_P])
    REFERENCES [dbo].[Pregleds]
        ([Broj_P])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DolaziPregled'
CREATE INDEX [IX_FK_DolaziPregled]
ON [dbo].[Dolazis]
    ([PregledBroj_P]);
GO

-- Creating foreign key on [UspostavljaPregledBroj_P], [UspostavljaDijagnozaOznaka_D] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_UspostavljaIzdaje]
    FOREIGN KEY ([UspostavljaPregledBroj_P], [UspostavljaDijagnozaOznaka_D])
    REFERENCES [dbo].[Uspostavljas]
        ([PregledBroj_P], [DijagnozaOznaka_D])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UspostavljaIzdaje'
CREATE INDEX [IX_FK_UspostavljaIzdaje]
ON [dbo].[Izdajes]
    ([UspostavljaPregledBroj_P], [UspostavljaDijagnozaOznaka_D]);
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