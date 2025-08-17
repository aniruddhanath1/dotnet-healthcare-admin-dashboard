<?php

namespace App\Repositories;

use App\Models\Appointment; // Eloquent model for SQL
use App\Models\Mongo\Appointment as MongoAppointment; // MongoDB model

class AppointmentRepository
{
    // SQL (DTO-based)
    public function getAll()
    {
        return Appointment::all();
    }

    public function getById($id)
    {
        return Appointment::findOrFail($id);
    }

    public function add($data)
    {
        return Appointment::create($data);
    }

    public function update($id, $data)
    {
        $appointment = Appointment::findOrFail($id);
        $appointment->update($data);
        return $appointment;
    }

    public function delete($id)
    {
        Appointment::destroy($id);
    }

    // MongoDB
    public function getAllMongo()
    {
        return MongoAppointment::all();
    }

    public function getByIdMongo($id)
    {
        return MongoAppointment::find($id);
    }

    public function addMongo($data)
    {
        return MongoAppointment::create($data);
    }

    public function updateMongo($id, $data)
    {
        $appointment = MongoAppointment::find($id);
        if ($appointment) {
            $appointment->update($data);
        }
        return $appointment;
    }

    public function deleteMongo($id)
    {
        MongoAppointment::destroy($id);
    }
}
