<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class AppointmentMongoRequest extends FormRequest
{
    public function authorize()
    {
        return true;
    }

    public function rules()
    {
        return [
            'patient_id' => 'required',
            'doctor_id' => 'required',
            'scheduled_at' => 'required|date',
            'status' => 'required|string',
            'notes' => 'nullable|string',
        ];
    }
}
