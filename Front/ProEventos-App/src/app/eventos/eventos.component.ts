import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';
import { compileClassMetadata } from '@angular/compiler';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  modalRef!: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem = 150;
  public margemImagem = 2;
  public exibirImagem = true;
  private _filtroListado = '';

  public get filtroLista(): string{
    return this._filtroListado;
  }

  public set filtroLista(value: string){
    this._filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this._filtroListado) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: {tema: string; local: string; }) =>
          evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
          evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private eventoService : EventoService,
    private modalService : BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(): void{
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Eventos','Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void{
    this.modalRef.hide();
    this.toastr.success('Hello world!','Toastr fun!');
  }

  decline(): void{
    this.modalRef.hide();
  }
}
