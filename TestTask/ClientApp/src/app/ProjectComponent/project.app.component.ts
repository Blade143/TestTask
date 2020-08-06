import { Component } from '@angular/core';
import { project } from '../models/project';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'project-component',
  templateUrl: './project.app.component.html',
  styleUrls: ['./project.app.component.css']
})
export class ProjectComponent {
    url: string = "http://localhost:49794/api/Project";

    project: project = new project();
    projects: project[];
    tableMode: boolean = true;

    constructor(private http: HttpClient){
    }

    ngOnInit() {
        this.http.get(this.url).subscribe((data: project[]) => this.projects = data);
    }

    cancel() {
        this.project = new project();
        this.tableMode = true;
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
     
    getProject(id: number) {
        return this.http.get(this.url + '/' + id);
    }
     
    updateProject(p: project){
        this.project = p;
    }

    createProject(project: project) {
        return this.http.post(this.url, project);
    }
    editProject(project: project) {
  
        return this.http.put(this.url, project);
    }
    delete(project: project) {
        return this.http.delete(this.url + '/' + project.id);
    }
}
