<?php

namespace App\Http\Controllers;

use App\Services\AppointmentService;
use App\Http\Requests\AppointmentDtoRequest;
use App\Http\Requests\AppointmentMongoRequest;
use Illuminate\Http\Request;

class AppointmentController extends Controller
{
    public function __construct(protected AppointmentService $service) {}

    // DTO-based endpoints (SQL)
    public function getAllDto()
    {
        return response()->json($this->service->getAll());
    }

    public function getDto($id)
    {
        return response()->json($this->service->getById($id));
    }

    public function createDto(AppointmentDtoRequest $request)
    {
        $appointment = $this->service->add($request->validated());
        return response()->json($appointment, 201);
    }

    public function updateDto(AppointmentDtoRequest $request, $id)
    {
        $this->service->update($id, $request->validated());
        return response()->noContent();
    }

    public function deleteDto($id)
    {
        $this->service->delete($id);
        return response()->noContent();
    }

    // Model-based (MongoDB) endpoints
    public function getAllMongo()
    {
        return response()->json($this->service->getAllMongo());
    }

    public function getByIdMongo($id)
    {
        return response()->json($this->service->getByIdMongo($id));
    }

    public function addMongo(AppointmentMongoRequest $request)
    {
        $appointment = $this->service->addMongo($request->validated());
        return response()->json($appointment, 201);
    }

    public function updateMongo(AppointmentMongoRequest $request, $id)
    {
        $this->service->updateMongo($id, $request->validated());
        return response()->noContent();
    }

    public function deleteMongo($id)
    {
        $this->service->deleteMongo($id);
        return response()->noContent();
    }
}
